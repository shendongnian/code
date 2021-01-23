    for (int i = 0; i < wordids.Count; ++i)
    {
        inputWeights.Add(new List<int>());
        for (int j = 0; j < hiddenids.Count; ++j)
        {
            inputWeights[i].Add(GetStrength(wordids[i], hiddenids[j]));
        }
    }
