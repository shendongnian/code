    public interface IFooRepository
    {
         IQueryable<Foo> GetFoo();
    }
    
    public FooService : IFooService
    {
         public List<Foo> FindByNameStartsWith(string startsWith)
         {
              return _fooRepo.GetFoo().Where(f=>f.Name.StartsWith(startsWith)).ToList();
         }
    }
