    class Foo
    {
       private IServiceProxy _serviceProxy;
       public Foo(IServiceProxy _serviceProxy)
       {
            _serviceProxy = serviceProxy;
       }
    
       public void Bar()
       {
           var staff = _serviceProxy.GetStaff();
       }
    } 
