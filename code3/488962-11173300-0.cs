    static void Main()
    {
        char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
        string text = "one\ttwo three:four,five six seven";
        System.Console.WriteLine("Original text: '{0}'", text);
        string[] words = text.Split(delimiterChars);
        System.Console.WriteLine("{0} words in text:", words.Length);
        foreach (string s in words)
        {
            System.Console.WriteLine(s);
        }
    }
