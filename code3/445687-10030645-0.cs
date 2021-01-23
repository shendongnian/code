    class Foo{
      protected Bar highlyCoupled = new highlyCoupled();
    
      public bool DoTheThing(){
        return highlyCoupled.doesTheThing();
      } 
    }
    ...
    //in your test suite    
    class FooTestProxy:Foo
    {
       public FooTestProxy(Bar testMock)
       {
          highlyCoupled = testMock;
       }   
    }
    //now when testing, instantiate your test proxy and pass it the mocked object
