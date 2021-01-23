    class Wrapper
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void ErrorHandler(int errorCode, string name, IntPtr data);
        [DllImport("somedll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int SetErrorHandler(ErrorHandler handler, IntPtr data);
        void MyErrorHandler(int errorCode, string name, IntPtr data)
        {
            lastError = errorCode;
            lastErrorName = name;
        }
        public Wrapper()
        {
            SetErrorHandler(MyErrorHandler, IntPtr.Zero);
        }            
            
        public int lastError { get; set; }
        public string lastErrorName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Wrapper wrapper = new Wrapper();
        }
    }
