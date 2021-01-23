    private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {                   
                }
                theCOMobject.Dispose();
    
                MethodFoo(false);
    
                disposed = true;
            }
        }
