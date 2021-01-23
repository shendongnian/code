    public interface IFooRepository
    {
         IQueryable<Foo> GetFoo();
    }
    
    public FooService : IFooService
    {
         public List<Foo> FindByNameStartsWith(string startsWith)
         {
              return new FooQuery().StartsWith(startsWith).Execute(_fooRepo.GetFoo());
         }
    }
