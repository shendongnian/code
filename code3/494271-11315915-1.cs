    #region Dispose
        private IntPtr handle;
        private Component component = new Component();
        private bool disposed = false;
        public WateOfMemory()
        {
        }
        public WateOfMemory(IntPtr handle)
        {
            this.handle = handle;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                component.Dispose();
                }
                CloseHandle(handle);
                handle = IntPtr.Zero;            
            }
            disposed = true;         
        }
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        ~WateOfMemory()      
        {
            Dispose(false);
        }
        #endregion
