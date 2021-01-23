    public IEnumerable<int> GetIntegers3()
    {
      if ( someCondition )
      {
        return new[] {4, 5, 6}; // compiler error
      }
      else
      {
        return GetIntegers3Deferred();
      }
    }
    private IEnumerable<int> GetIntegers3Deferred()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
