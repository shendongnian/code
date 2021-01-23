    // note this is a JSON example, but you can replace it with whatever Markup parser you like.
    public class SqlQueriesFromJsonModel {
        public class Query{
            public string Caption { get; set; }
            public string Query { get; set; }
        }
        public List<Query> Queries{ get; set; }
    }
