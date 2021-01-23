    string word = TelephoneFinder.First("867");
    while (!String.IsNullOrEmpty(word))
    {
        Console.WriteLine(word);
        word = TelephoneFinder.Next(word);
    }
