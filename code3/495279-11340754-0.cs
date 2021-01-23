    internal class MyDbActions
    {
        private MyDbContext _myDbContext;
        private MyDbContext Db
        {
            get
            {
                if (_myDbContext == null) _myDbContext = new MyDbContext();
                return _myDbContext;
            }
        }
    
        internal void Add(SomeClass c)
        {
            Db.Table.AddObject(c);
            Db.SubmitChanges();
            Db.Dispose();
        }
    }
