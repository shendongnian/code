    using (var reader = new StreamReader(@"test.txt"))
    {
        var textInBetween = new List<string>();
        bool startTagFound = false;
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (String.IsNullOrEmpty(line))
                continue;
            if (!startTagFound)
            {
                startTagFound = line.StartsWith("Condition");
                continue;
            }
            bool endTagFound = line.StartsWith("Condition");
            if (endTagFound)
            {
                // Do stuff with the text you've read in between here
                // ...
                textInBetween.Clear();
                continue;
            }
                    
            textInBetween.Add(line);
        }
    }
