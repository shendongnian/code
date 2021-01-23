    public IEnumerable TheMethod(SomeParameter)
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
