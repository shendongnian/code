    Process[] proc = Process.GetProcesses();
    foreach (Process theprocess in proc)
    {
        if (theprocess.MainWindowTitle != string.Empty)
        {
            Console.WriteLine("Process: {0} ID: {1} WinTitle: {2} ", theprocess.ProcessName, theprocess.Id,theprocess.MainWindowTitle);
        }
        else
        {
            Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
        }
    }
