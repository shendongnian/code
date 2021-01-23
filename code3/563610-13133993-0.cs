    class CSUnmangedTestClass : IDisposable
    {
        #region P/Invokes
        [DllImport(@"E:\VS2012Tests\test\Debug\DllImport.dll", EntryPoint="#1")]
        private static extern IntPtr Foo_Create();
        [DllImport(@"E:\VS2012Tests\test\Debug\DllImport.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Foo_Bar(IntPtr pFoo);
        [DllImport(@"E:\VS2012Tests\test\Debug\DllImport.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Foo_Delete(IntPtr pFoo);
        #endregion
        #region Members
        // variable to hold the C++ class's this pointer
        private IntPtr m_pNativeObject;
        #endregion
        public CSUnmangedTestClass()
        {
            this.m_pNativeObject = Foo_Create();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool bDisposing)
        {
            if (this.m_pNativeObject != IntPtr.Zero)
            {
                Foo_Delete(m_pNativeObject);
                this.m_pNativeObject = IntPtr.Zero;
            }
            if (bDisposing)
            {
                // No need to call the finalizer since we've now cleaned up the unmanged memory
                GC.SuppressFinalize(this);
            }
        }
        ~CSUnmangedTestClass()
        {
            Dispose(false);
        }
        #region Wrapper methods
        public int Bar()
        {
            return Foo_Bar(m_pNativeObject);
        }
        #endregion
    }
