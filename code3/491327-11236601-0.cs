    public IEnumerable<double[]> GetResults()
    {
      for (int i = 0; i < 1000; x++)
      {
        yield return examples[i][0];
      }
    }
