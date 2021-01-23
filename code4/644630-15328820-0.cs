    var reader = new StreamReader(File.OpenRead(@"C:\mthesaur.txt"));
    var dict = new Dictionary<string, string>();
    while (!reader.EndOfStream)
    {
        // Read the file line by line.
        var line = reader.ReadLine();
        
        // If the line isn't null, we can use it.  This shouldn't happen but it is a good sanity check.
        if (line == null) continue;
        // Split the line by the delimiter (a comma) so we can get the main word, the first one on the line.
        var splitLine = line.Split(',');
        var mainWord = splitLine[0];
        // To save us from having to loop through and only get the indexes above 0 (eg, skip the main word) we will just simply remove it from the line so we have just synonyms.
        line = line.Replace(mainWord + ",", string.Empty);
        // Now we make use of the dictionary type in C# and add the mainword as the key and the synonyms as the value.
        dict.Add(mainWord, line);
    }
