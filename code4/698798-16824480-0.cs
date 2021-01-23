    public void SomeQueryMethod(IQueryable<dynamic> query)
    {
           var result = query.First();
           var a = result.a; //dynamic resolution
    } 
    .... 
    SomeQueryMethod(emp); //this should work
