    public class MyThreadSafeClass : IDisposable
    {
        private readonly object lockObj = new object();
        private MyRessource myRessource = new MyRessource();
        public void DoSomething()
        {
            Data data;
            lock (lockObj)
            {
                if (myResource == null) throw new ObjectDisposedException("");
                data = myResource.GetData();
            }
            // Do something with data
        }
        public void DoSomethingElse(Data data)
        {
            // Do something with data
            lock (lockObj)
            {
                if (myRessource == null) throw new ObjectDisposedException("");
                myRessource.SetData(data);
            }
        }
        ~MyThreadSafeClass()
        {
            Dispose(false);
        }
        public void Dispose() 
        { 
            Dispose(true); 
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing) 
        {
            if (disposing)
            {
                lock (lockObj)
                {
                    if (myRessource != null)
                    {
                        myRessource.Dispose();
                        myRessource = null;
                    }
                }
                //managed ressources
            }
            // unmanaged ressources
        }
    }
