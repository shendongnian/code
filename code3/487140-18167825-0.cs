    [QueryInterceptor("Entities")]
    public Expression<Func<Entity,bool>> OnQueryFares()
    {
        // Assuming e has two properties Name and Age. 
        return e => e.Name=="John" && e.Age=23 ;
    }
