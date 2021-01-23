    using System.Runtime.InteropServices;
    
    namespace myNamespace
    {
        public class myClass
        {
            [DllImport("myLib.so", EntryPoint = "myFunction")]
            public static extern unsafe void myFunction(float* var1, float* var2);
        }
    }
