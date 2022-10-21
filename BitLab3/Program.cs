
char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 
    'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

int keyA, keyB;
string text, result;

static int ReversA(int a, char[] alphabet)
{
    for (int x = 1; x <= alphabet.Length; x++)
    {
        int temp = (a * x) % alphabet.Length;
        if (temp == 1) 
        {
            Console.WriteLine("Nasz odwrotnosc to: " + x);
            return x; 
        }
    }
    throw new Exception("Nie istnieje odwrotosc");
}

static string Encrypt(string text, char[] alphabet, int keyA, int keyB)
{
    text = text.ToLower();
    char[] textToEncrypt = text.ToCharArray();
    int alphabetLenght = alphabet.Length;
    int length = textToEncrypt.Length;
    char[] encryptedChar = new char[length];
    for (int i = 0; i < textToEncrypt.Length; i++)
    {
        if (!(textToEncrypt[i] == ' '))
        {
            var letter = textToEncrypt[i];
            int index = Array.IndexOf(alphabet, letter);
            int newIndex = (((keyA * index) + keyB) % alphabetLenght) % alphabetLenght;
            if (newIndex < 0) newIndex = alphabetLenght + newIndex;
            char newLetter = alphabet[newIndex];
            encryptedChar[i] = newLetter;
        }
        else encryptedChar[i] = textToEncrypt[i];
    }

    string encrypToText = String.Join("", encryptedChar);
    return encrypToText;
}

static string UnEncrypt(string text, char[] alphabet, int keyA, int keyB)
{
    text = text.ToLower();
    char[] textToEncrypt = text.ToCharArray();
    int alphabetLenght = alphabet.Length;
    int length = textToEncrypt.Length;
    char[] encryptedChar = new char[length];
    keyA = ReversA(keyA, alphabet);
    for (int i = 0; i < textToEncrypt.Length; i++)
    {
        if (!(textToEncrypt[i] == ' '))
        {
            var letter = textToEncrypt[i];
            int index = Array.IndexOf(alphabet, letter);
            int newIndex = (keyA*(index - keyB)) % alphabetLenght;
            if (newIndex < 0) newIndex = alphabetLenght + newIndex;
            char newLetter = alphabet[newIndex];
            encryptedChar[i] = newLetter;
        }
        else encryptedChar[i] = textToEncrypt[i];
    }

    string encrypToText = String.Join("", encryptedChar);
    return encrypToText;
}


Console.WriteLine("Wszystkie dostępne pierwsze wartości kodu:");
for (int i = 1; i < alphabet.Length; i++)
{
    int m = alphabet.Length;
    int a = i;
    while (a != m)
    {
        if (a > m)
            a -= m;
        else
            m -= a;
    }
    if (a == 1) Console.WriteLine("   " + i);
}

Console.WriteLine();
Console.Write("Podaj pierwszą wartość klucza: ");
keyA = Convert.ToInt32(Console.ReadLine());
Console.Write("Podaj drugą wartość klucza: ");
keyB = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Podaj tekst do zaszyfrowania");
text =  Console.ReadLine();

result = Encrypt(text, alphabet, keyA, keyB);

Console.WriteLine();
Console.WriteLine("Tak wygląda text zaszyfrowany: " + result);

Console.WriteLine();
Console.WriteLine("Teraz odwracam proces szyfrowania");

Console.WriteLine(UnEncrypt(result, alphabet, keyA, keyB));
