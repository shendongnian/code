    interface IRepository
    {
        bool Save<T>(T entity)
            where T : class;
    }
    class FooRepository : IRepository
    {
        bool Save<T>(T entity)
        {
        }
        bool Save(Foo entity)
        {
        }
    }
