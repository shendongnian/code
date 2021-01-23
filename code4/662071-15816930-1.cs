    static void Main(string[] args)
    { 
        foreach(string s in ListDevices())
        {
            Console.WriteLine(s);
        }
    }
    [DllImport("MyUnmanaged.dll")]
    [return: MarshalAs(UnmanagedType.SafeArray)] 
    private extern static string[] ListDevices();
