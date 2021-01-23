    public class TheRepresentativeType {
        public ... SomeVariable {get;set;}
        public ... AnotherVariable {get;set;}
    }
    public IEnumerable<TheRepresentativeType> TheMethod(SomeParameter)
    {
       using (MyDC TheDC = new MyDC())
       {
         var TheQueryFromDB = (....
                               select new TheRepresentativeType{ SomeVariable = ....,
                                            AnotherVariable = ....}
                               ).ToList();
         return TheQueryFromDB;
       } 
    }
