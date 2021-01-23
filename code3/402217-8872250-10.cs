    public enum AvailableQuery
    {
        SelectFoo
    }
    public class QueryLibrary
    {
        private readonly AvailableQueryConfigSection _availableQueries;
        public QueryLibrary()
        {
            this._availableQueries = 
                (AvailableQueryConfigSection)
                ConfigurationManager.GetSection("queries");
        }
        public string GetQuery(AvailableQuery query)
        {
            // return query from availableQueries
        }
    }
