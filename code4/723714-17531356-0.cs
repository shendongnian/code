    public struct SYSTEMTIME
    {
       public ushort wYear, wMonth, wDayOfWeek, wDay,
              wHour, wMinute, wSecond, wMilliseconds;
    }
    [DllImport("kernel32.dll")]
    public extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);
    [DllImport("kernel32.dll")]
    public extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);
 
    Console.WriteLine(DateTime.Now.ToString());
    SYSTEMTIME st = new SYSTEMTIME();
    GetSystemTime(ref st);
  
    Console.WriteLine("Adding 1 hour...");
    st.wHour = (ushort)(st.wHour + 1 % 24);
    if (SetSystemTime(ref st) == 0)
        Console.WriteLine("FAILURE: SetSystemTime failed");
   
    Console.WriteLine(DateTime.Now.ToString());
    Console.Read();
    Console.WriteLine("Setting time back...");
    st.wHour = (ushort)(st.wHour - 1 % 24);
    SetSystemTime(ref st);
    Console.WriteLine(DateTime.Now.ToString());
    Console.WriteLine("Press Enter to exit");
    Console.Read();
