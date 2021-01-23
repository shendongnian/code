    class Program
    {
        static void Main(string[] args)
        {
            var a = new MyClass();
            var result = a.ShowMessage();
        }
    }
    class FunctionLoader
    {
        [DllImport("Kernel32.dll")]
        private static extern IntPtr LoadLibrary(string path);
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        public static Delegate LoadFunction<T>(string dllPath, string functionName)
        {
            var hModule = LoadLibrary(dllPath);
            var functionAddress = GetProcAddress(hModule, functionName);
            return Marshal.GetDelegateForFunctionPointer(functionAddress, typeof (T));
        }
    }
    public class MyClass
    {
        static MyClass()
        {
            // Load functions and set them up as delegates
            // This is just an example - you could load the .dll from any path,
            // and you could even determine the file location at runtime.
            MessageBox = (MessageBoxDelegate) 
                FunctionLoader.LoadFunction<MessageBoxDelegate>(
                    @"c:\windows\system32\user32.dll", "MessageBoxA");
        }
        private delegate int MessageBoxDelegate(
            IntPtr hwnd, string title, string message, int buttons); 
        
        /// <summary>
        /// This is the dynamic P/Invoke alternative
        /// </summary>
        static private MessageBoxDelegate MessageBox;
        /// <summary>
        /// Example for a method that uses the "dynamic P/Invoke"
        /// </summary>
        public int ShowMessage()
        {
            // 3 means "yes/no/cancel" buttons, just to show that it works...
            return MessageBox(IntPtr.Zero, "Hello world", "Loaded dynamically", 3);
        }
    }
