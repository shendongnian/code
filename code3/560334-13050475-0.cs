    class Recipe : IDisposable
    {
        bool isDisposed = false;
        TableAdapter myDisposableMember;
        public void Dispose()
        {
            Dispose(true);
            GC.SupressFinalize(this);
        }
        public virtual Dispose(bool isDisposing)
        {
            if (!isDisposed) //only clean up once
            {
                //clean up unmanaged resource here
                //in this case we don't have any
                //clean up managed resources (IE those that implemetn IDisposable only if
                //Dispose() was called (not the case when invoked during finalisation)
                if (isDisposing)
                {
                    if(myDisposableMember = null)
                    {
                        myDisposableMember.Dispose()
                        myDisposablemember = null;
                    }
                }
                //mark this instance as cleaned up
                isDisposed = true;
            }
        }
        
        //if our class has any unmanaged resources you implement a destructor to guarantee
        //that they're freed. We don't have any here so we don't implement it.
        //~Recipe()
        //{
        //    Dispose(false);
        //}
    }
