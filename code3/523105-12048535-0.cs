    using System;
    using System.Runtime.InteropServices;
    
    namespace MyNamespace
    {
        class GFW
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
    
            public bool IsActive(IntPtr handle)
            {
                IntPtr activeHandle = GetForegroundWindow();
                return (activeHandle == handle);
            }
        }
    }
