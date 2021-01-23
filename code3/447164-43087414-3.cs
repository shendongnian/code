    public List<(int SomeVariable, string AnotherVariable)> TheMethod(SomeParameter)
    {
      using (MyDC TheDC = new MyDC())
      {
         var TheQueryFromDB = (....
                           select new { SomeVariable = ....,
                                        AnotherVariable = ....}
                           ).ToList();
          return TheQueryFromDB
                    .Select(s => (
                         SomeVariable = s.SomeVariable, 
                         AnotherVariable = s.AnotherVariable))
                     .ToList();
      }
    }
