    public class Sample : ClassBase<SomeService>
    {
         public Bar CallFoo()
         {
              FooRequest request = ...
              var response = Invoke(svc => svc.Foo(request));
              return new Bar(response);
         }
    }
