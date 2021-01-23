    public IEnumerable<int> GetIntegers()
    {
      if ( someCondition )
      {
        yield! return new[] {4, 5, 6};
      }
      else
      {
        yield return 1;
        yield return 2;
        yield return 3;
      }
    }
