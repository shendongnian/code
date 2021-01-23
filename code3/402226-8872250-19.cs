    public class FooRepository
    {
        public Foo GetFooByValue(string value)
        {
            string query = this._queryLibrary
                .GetAvailableQuery(AvailableQuery.SelectFoo)
                .Replace("{value}", value); // <- or better still, use parameters
            using (IDataReader reader = this._dbProvider.ExecuteReader(query))
            {
                // Or get the values out of the reader here and pass them into 
                // a constructor instead of passing in the reader itself:
                return new Foo(reader);
            }
        }
    }
