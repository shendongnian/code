        protected virtual void
        Dispose
            (bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // send a signal to stop the thread.
                    _stopTheThread = true;
                    // Join the thread - we could timeout here but it should be the
                    // responsibility of the thread owner to ensure it exits
                    // If this is hanging then the owning object hasn't termianted
                    // its thread
                    TheThread.Join();
                    TheThread = null;
                }
                // Now deal with unmanaged resources!
                DestroySomeUnmangedResouces();
            }
            disposed = true;
        }
           
