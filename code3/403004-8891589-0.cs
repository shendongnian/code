    class HelloWorld
    {
      [DllImport("TestLib.dll")]
      public static extern void DisplayHelloFromDLL(IntPtr a);
      static void Main ()
      {
        string a = "Hello";
        DisplayHelloFromDLL(System.Runtime.Marshal.StringToHGlobalAnsi(a));
      }
    }
