    public delegate void MyCallback();
    [DllImport("MYDLL.DLL")] public static extern void MyUnmanagedApi(MyCallback callback);
    public static void Main()
    {
      MyUnmanagedApi(
        delegate()
        {
          Console.WriteLine("Called back by unmanaged side");
        }
       );
    }
