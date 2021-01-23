    [DllImport("kernel32.dll", EntryPoint = "GetCurrentThread", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr GetCurrentThread();
    [DllImport("kernel32.dll", EntryPoint = "QueueUserAPC", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    public static extern uint QueueUserAPC(ApcDelegate pfnAPC, IntPtr hThread, UIntPtr dwData);
    
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void ApcDelegate(UIntPtr dwParam);
    [DllImport("kernel32.dll", EntryPoint = "DuplicateHandle", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    public static extern bool DuplicateHandle([In] System.IntPtr hSourceProcessHandle, [In] System.IntPtr hSourceHandle, [In] System.IntPtr hTargetProcessHandle, out System.IntPtr lpTargetHandle, uint dwDesiredAccess, [MarshalAsAttribute(UnmanagedType.Bool)] bool bInheritHandle, uint dwOptions);
    [DllImport("kernel32.dll", EntryPoint = "GetCurrentProcess", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    public static extern IntPtr GetCurrentProcess();
    
    static IntPtr hThread;
    public static void SomeMethod(object value)
    {
    	DuplicateHandle(GetCurrentProcess(), GetCurrentThread(), GetCurrentProcess(), out hThread, 0, false, 2);
    	while (true)
    	{
    		Console.WriteLine(".");
    		Thread.Sleep(1000);
    	}
    }
    
    private static void APC(UIntPtr data)
    {
    	Console.WriteLine("Callback invoked");
    }
    
    static void Main(string[] args)
    {
    	Console.WriteLine("in Main\n");
    
    	Thread t = new Thread(Program.SomeMethod);
    	t.Start();
    
    	Thread.Sleep(1000); // wait until the thread fills out the hThread member -- don't do this at home, this isn't a good way to synchronize threads...
    	uint result = QueueUserAPC(APC, hThread, (UIntPtr)0);
    
    	Console.ReadLine();
    }
