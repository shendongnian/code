    private void CompareMatchesImpl()
    {
       foreach (var hashEntry in calculatedHashes.GetConsumingEnumerable())
       {
          // TODO: obviously return type is up to you
          string matchResult = GetMathResultTODO(hashEntry.Item1, hashEntry.Item2);
          comparedMatches.Add(matchResult);
       }
    }
