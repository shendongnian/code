        string wordToFind = "cat";
        string sentance = "the cat is here with the cagt";
        int count = 0;
        foreach (var word in sentance.Split(' '))
        {
            if (word.Equals(wordToFind, StringComparison.OrdinalIgnoreCase))
            {
                count++;
                continue;
            }
            foreach (var chr in word)
            {
                if (word.Replace(chr.ToString(), "").Equals(wordToFind, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
        }
        // returns 2
