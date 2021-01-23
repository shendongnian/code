    public T SelectProjection<T>(Func<T> personFunc) 
    {
            return personFunc();
    }
     Person p = new Person();
     p.Address = "TestAdress";
     var x = p.SelectProjection<dynamic>(() => new {p.Address});
