    public class FooRepository
    {
        public Foo GetFooByValue(string value)
        {
            string query = this._queryLibrary
                .GetAvailableQuery(AvailableQuery.SelectFoo)
                .Replace("{value}", value); // <- or better still, use parameters
            using (IDataReader reader = this._dbProvider.ExecuteReader(query))
            {
                return new Foo(reader);
            }
        }
    }
