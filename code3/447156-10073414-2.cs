    public IEnumerable<dynamic> TheMethod(SomeParameter)
    {
       using (MyDC TheDC = new MyDC())
       {
         var TheQueryFromDB = (....
                               select new TheRepresentativeType{ SomeVariable = ....,
                                            AnotherVariable = ....}
                               ).ToList();
         return TheQueryFromDB; //You may need to call .Cast<dynamic>(), but I'm not sure
       } 
    }
