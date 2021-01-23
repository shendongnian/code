    interface IFooService
    {
        FooViewModel GetFoo(int id);
    }
    public class FooService : IFooService
    {
        public FooViewModel GetFoo(int id)
        {
            var foo = dbContext.Foo.Where(f => f.Id == id).Select(f => new FooViewModel {
                Bar = f.Bar,
                Blah = f.Blah
            }).FirstOrDefault();
            // I let AutoMapper take care of the mapping for me
            var foo = Mapper.Map<FooViewModel>(dbContext.Foo.Where(f => f.Id == id).FirstOrDefault());
            return foo;
        }
    }
