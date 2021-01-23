    static void Main(string[] args)
    {
        string sentence = @"Hello fri3nd, you're
       looking          good today!";
        var assoc = (Dictionary<int,string>)str_word_count(sentence, WORD_FORMAT.ASSOC, string.Empty);
        var array = (string[])str_word_count(sentence, WORD_FORMAT.ARRAY, string.Empty);
        var number = (int)str_word_count(sentence, WORD_FORMAT.NUMBER, string.Empty);
        //test the plain array
        Console.WriteLine("Array\n(");
        for (int i = 0; i < array.Length; i++)
            Console.WriteLine("\t[{0}] => {1}", i, array[i]);
        Console.WriteLine(")");
        // test the associative
        Console.WriteLine("Array\n(");
        foreach (var kvp in assoc)
            Console.WriteLine("\t[{0}] => {1}", kvp.Key, kvp.Value);
        Console.WriteLine(")");
        //test the charlist:
        array = (string[])str_word_count(sentence, WORD_FORMAT.ARRAY, "àáãç3");
        Console.WriteLine("Array\n(");
        for (int i = 0; i < array.Length; i++)
            Console.WriteLine("\t[{0}] => {1}", i, array[i]);
        Console.WriteLine(")");
        //test the number
        Console.WriteLine("\n{0}", number);
        Console.Read();
    }
