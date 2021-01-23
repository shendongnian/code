    public class FooRepository
    {
        public Foo GetFooByValue(string value)
        {
            string query = this._queryLibrary
                .GetAvailableQuery().Replace("{value}", value);
            using (IDataReader reader = this._dbProvider.ExecuteReader(query))
            {
                return new Foo(reader);
            }
        }
    }
