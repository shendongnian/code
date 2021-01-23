    public sealed class MyDal implements IDisposable
    {
        private MyEntities ent = new MyEntities();
        void Foo()
        { 
           ent.Mytable.where......
           ....
        }
        
        public void Dispose()
        {
            ent.Dispose();
        }
    }
    
