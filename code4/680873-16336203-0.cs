    using System;
    using System.Runtime.InteropServices;
    
    namespace MyNameSpace
    {
        public class MyClass
        {
            [DllImport("DllMain.dll", EntryPoint = "HelloWorld")]
            public static extern void HelloWorld();
    
            [DllImport("DllMain.dll", EntryPoint = "ShowMe")]
            public static extern void ShowMe();
        }
    }
