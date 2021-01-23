    List<string> list = new List<string>();
    dictionary = new Dictionary<string, string>();  /* CREATE ONE DICTIONARY */
    using (StreamReader reader = new StreamReader("dictionarylist.csv"))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] split = line.Split(',');
            dictionary.Add(split[0], split[1]);
        }
    }
