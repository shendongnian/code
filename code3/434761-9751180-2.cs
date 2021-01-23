    List<ChildObj> childsCreated = new List<ChildObj>();
    public ChildObj CreateObj()
    {
        ChildObj obj = new ChildObj();
        childsCreated.Add(obj);
        return obj;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        // Check to see if Dispose has already been called.
        if(!this.disposed)
        {
            if(disposing)
            {
                foreach(ChildObj obj in childsCreated)
                    obj.ProviderDisposed = true;
            }
            disposed = true;
        }
    }
    public class ChildObj   
    {   
        private DisposableObj m_provider;   
        private bool m_providerDisposed = false;
       
        public bool ProviderDisposed 
        { set { m_providerDisposed = true; } }
    
        public void DoSomething()   
        {   
            if(m_providerDisposed == false)
                 m_provider.GetSomething();
            // else // as from **@BrokenGlass answer**
            //     throw new ObjectDisposedException();   
        }   
        // ...   
    }  
