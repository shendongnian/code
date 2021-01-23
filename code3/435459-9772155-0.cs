    public IEnumerable<int> GetOddPositiveNumbers()
    {
       int i = 0;
       while (true)
       {          
          yield return 2*(i++)+1;
       }
    }
