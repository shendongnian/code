    static Process TestProc = new Process();
    static ProcessStartInfo TestProcStart = new ProcessStartInfo();
    try
    {
        TestProcStart.WindowStyle = ProcessWindowStyle.Hidden;
        TestProcStart.FileName = args[++i];
        TestProc.StartInfo = TestProcStart;
        TestProc.Start();
        TestProc.Kill();
        Run = args[i];
    }
    catch(Win32Exception e)
    {
        switch(e.NativeErrorCode)
        {
            case 2: Console.WriteLine("ERROR: File " + args[i] + " not found!"); return;
            case 5: Console.WriteLine("ERROR: Access denied to " + args[i] + "!"); return;
            default: Console.WriteLine("ERROR " + e.NativeErrorCode + ": " + e.Message); return;
        }
    }
