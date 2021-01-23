    static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
    }
    class Program
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int MultiplyByTen(int numberToMultiply);
        static void Main(string[] args)
        {
                IntPtr pDll = NativeMethods.LoadLibrary(@"PathToYourDll.DLL");
                //oh dear, error handling here
                //if (pDll == IntPtr.Zero)
                IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, "MultiplyByTen");
                //oh dear, error handling here
                //if(pAddressOfFunctionToCall == IntPtr.Zero)
                MultiplyByTen multiplyByTen = (MultiplyByTen)Marshal.GetDelegateForFunctionPointer(
                                                                                        pAddressOfFunctionToCall,
                                                                                        typeof(MultiplyByTen));
                int theResult = multiplyByTen(10);
                bool result = NativeMethods.FreeLibrary(pDll);
                //remaining code here
                Console.WriteLine(theResult);
        }
    } 
