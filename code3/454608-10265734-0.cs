    public class CachedFooProperty : IFooProperty
    {
       public CachedFooProperty(IRepository<Foo> fooRepo)
       {
          Foo = fooRepo.GetFoo();
       }
       public Foo Foo{get;private set;}
    }
