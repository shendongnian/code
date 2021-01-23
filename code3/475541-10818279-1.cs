    class Foo
    {
       protected delegate void CreateResource(object parameter);
    
       protected Foo(CreateResource res)
       {
           Initialize(res);
       }
       protected void Initialize(CreateResource res)
       {
       }
    
       public Foo(string resourceName)        
       {
           Initialize(CreateStreamRes(res));
       }
    
       protected void CreateStreamRes(object o)
       {
       }
    }
