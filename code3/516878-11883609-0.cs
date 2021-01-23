        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr LoadLibraryEx(string libraryPath, IntPtr fileHandle, int actionFlag);
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern bool FreeLibrary(IntPtr libraryHandle);
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetProcAddress(IntPtr dllPointer, string functionName);
        IntPtr ptr = IntPtr.Zero;
        private delegate void setX (int i);
        private delegate int getX();
        
        private setX setXDel;
        private getX getXDel;
        public Constructor()
        {
            loadLib();
        }
   
        public void YourMethod()
        {
            setXDel(100);
            int y = getXDel();
            Console.WriteLine(y.ToString());
        }
        private void loadLib()
        {
            string path = "your dll path";
            ptr = LoadLibraryEx(path, IntPtr.Zero, 0);
            if (ptr == IntPtr.Zero)
                throw new Exception("Cannot load dll.");
            IntPtr addressPtr = GetProcAddress(ptr, "setX");
            setXDel = (setX)Marshal.GetDelegateForFunctionPointer(addressPtr, typeof(setX));
            addressPtr = GetProcAddress(unrarPtr, "getX");
            getXDel = (getX)Marshal.GetDelegateForFunctionPointer(addressPtr, typeof(getX));
        }
        public void Dispose()
        {
            if (ptr != IntPtr.Zero)
            {
                FreeLibrary(ptr);
            }
        }
