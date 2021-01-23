    public static bool verifiers()
    {
        ...
        return verify;
    }
    ...
    if (Form1.verifiers())
    {
        System.Threading.Thread.Sleep(500);
        SetForegroundWindow(proc.MainWindowHandle);
    }
