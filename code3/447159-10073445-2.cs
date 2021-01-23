    public List<SomeClass> TheMethod(SomeParameter)
    {
      using (MyDC TheDC = new MyDC())
      {
         var TheQueryFromDB = (....
                               select new SomeClass{ SomeVariable = ....,
                                            AnotherVariable = ....}
                               ).ToList();
    
          return TheQueryFromDB.ToList();
        }
    }
    
    public class SomeClass{
       public string SomeVariable{get;set}
       public string AnotherVariable{get;set;}
    }
