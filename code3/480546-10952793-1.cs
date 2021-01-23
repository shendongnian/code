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
        System.Threading.Thread.Sleep(50); //FreeConsole sometimes doesn't finish closing straight away which means your form flickers to the front and then minimizes.
        this.ShowInTaskbar = true;        
        this.Show(); 
    }
    //---
    private void Enter_Console_Code()
    { 
        string line = string.Empty;
        while ((line = Console.ReadLine()) != "q")
            Console.WriteLine(line); //pointless code ftw!
    }
