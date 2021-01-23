    var inputWeights = new List<List<int>>();
    foreach (int wordid in wordids)
    {
        inputWeights.Add(new List<int>());
        for (int i = 0; i < hiddenids.Count; ++i)
        {
            inputWeights[i].Add(GetStrength(wordid, hiddenids[i]));
        }
    }
