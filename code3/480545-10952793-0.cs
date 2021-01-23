    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AllocConsole();
    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool FreeConsole();
    //--- form code
    if (Do_validation() && AllocConsole())
    {
        this.Hide();
        this.ShowInTaskbar = false;
        Enter_Console_Code();
        FreeConsole();
        this.Show();
        this.ShowInTaskbar = true;
    }
    //---
    private void Enter_Console_Code()
    { 
        string line = string.Empty;
        while ((line = Console.ReadLine()) != "q")
            Console.WriteLine(line); //pointless code ftw!
    }
