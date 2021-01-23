    public class XTypeQueries : QueryLibrary
    {
        public XTypeQueries (EntityModel db) : base(db) { }
        public IQueryable<Object> DoSomeQuery()
        {
            return from ... in this.db...
                   select ...;
        }
    }
