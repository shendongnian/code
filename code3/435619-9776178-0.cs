    while ((line = reader.ReadLine()) != null)
    {
        //Add to dictionary
        dictionary = new Dictionary<string, string>();  /* DON'T CREATE NEW DICTIONARIES */
        string[] split = line.Split(',');
        dictionary.Add(split[0], split[1]);
    }
