    interface IFooService
    {
        FooDTO GetFoo(int id);
    }
    public class FooService : IFooService
    {
        public FooDTO GetFoo(int id)
        {
            var foo = dbContext.Foo.Where(f => f.Id == id).Select(f => new FooDTO {
                Bar = f.Bar,
                Blah = f.Blah
            }).FirstOrDefault();
            // I let AutoMapper take care of the mapping for me
            var foo = Mapper.Map<FooDTO>(dbContext.Foo.Where(f => f.Id == id).FirstOrDefault());
            return foo;
        }
    }
