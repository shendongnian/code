    class HelloWorld
    {
      [DllImport("TestLib.dll")]
      public static extern void DisplayHelloFromDLL(IntPtr a);
      static void Main ()
      {
        string a = "Hello";
        var ptr = System.Runtime.Marshal.StringToHGlobalAnsi(a);
        DisplayHelloFromDLL(ptr);
        System.Runtime.Marshal.FreeHGlobal(ptr);
      }
    }
