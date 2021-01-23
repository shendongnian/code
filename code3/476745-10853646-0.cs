      public static unsafe class WrapCDll {
        private const string DllName = "c_functions.dll";
    
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void do_stuff_in_c(byte* arg);
      }
