    public Foo2 NonAsyncNonVoidMethod() 
    {
       Foo f = GetFoo();
       PewPew p = SomeMethod().Result; //But be aware that Result will block thread
      
       return GetFoo2(p);
    }
