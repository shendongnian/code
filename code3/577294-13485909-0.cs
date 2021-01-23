    string s = "This is a sentence. Also this counts. This one is also a thing.";
    string[] sentences = s.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
    foreach(string sentence in sentences)
    {
        Console.WriteLine(sentence.Split(' ').Length + " words in sentence *" + sentence + "*");
    }
