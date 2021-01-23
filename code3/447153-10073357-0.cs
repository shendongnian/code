    public List<object> TheMethod(SomeParameter)
    {
      using (MyDC TheDC = new MyDC())
      {
         var TheQueryFromDB = (....
                               select new { SomeVariable = ....,
                                            AnotherVariable = ....}
                               ).ToList();
    
          return TheQueryFromDB ;
        }
    }
    
