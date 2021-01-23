    // filter all words that dont match the required length
    var candidateWords = wordList.Where(x => x.Length == wordLength);
            
    // define a result set holding all the words and all their matches
    Dictionary<string, List<int>> refinedWordSet = new Dictionary<string, List<int>>();
    foreach (string word in candidateWords)
    {
        List<int> matches = new List<int>() { 0 };
        int currentMatchCount = 0;
        foreach (char character in word)
        {
            if (requiredCharacters.Contains(character))
            {
                currentMatchCount++;
            }
            else
            {
                // if there were previous matches
                if (currentMatchCount > 0)
                {
                    // save the current match
                    matches.Add(currentMatchCount);
                    currentMatchCount = 0;
                }
            }
        }
        // if there was a match at the end
        if (currentMatchCount > 0)
        {
            // save the last match
            matches.Add(currentMatchCount);
        }
        refinedWordSet.Add(word, matches);
    }   
    // sort by a combination of the total amount of matches as well as the highest match
    var goupedRefinedWords = from entry in refinedWordSet
                                group entry.Key by new { Max = entry.Value.Max(), Total = entry.Value.Sum() } into grouped
                                select grouped;
    foreach (var entry in goupedRefinedWords)
    {
        Console.WriteLine("Word list with best match: {0} and total match {1}: {2}", 
            entry.Key.Max,
            entry.Key.Total,
            entry.Aggregate("", (result, nextWord) => result += nextWord + ", "));
    }
    Console.ReadLine();
