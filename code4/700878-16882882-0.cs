    public class DbHelper : IDisposable
    {
        private MyEntities ent;
        public DbHelper()
        {
            ent = new MyEntities();
        }
        public void Foo()
        {
            //...
        }
        public void Bar()
        {
            //...
        }
        public void Dispose() // implementation of IDisposable
        {
            ent.Dispose();
        }
    }
