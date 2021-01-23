    public class HashDllAutoPtr : IDisposable
    {
        [DllImport(@"C:\Hash.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ph_dct_free(IntPtr ptr);
        public HashDllAutoPtr(IntPtr ptr)
        {
            Ptr = ptr;
        }
        ~HashDllAutoPtr()
        {
            Dispose();
        }
        public IntPtr Ptr
        {
            get;
            private set;
        }
        #region IDisposable Members
        public void Dispose()
        {
            if (Ptr != IntPtr.Zero)
            {
                ph_dct_free(Ptr);
            }
            Ptr = IntPtr.Zero;
        }
        #endregion
    }
