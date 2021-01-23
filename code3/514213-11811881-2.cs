    using System.Runtime.InteropServices;
    using EnvDTE;
    [STAThread]
    public static void Main()
    {
        MessageFilter.Register();
        var process = GetProcess(7532);
        if (process != null)
        {
            process.Attach();
            Console.WriteLine("Attached to {0}", process.Name);
        }
        MessageFilter.Revoke();
        Console.ReadLine();
    }
    private static Process GetProcess(int processID)
    {
        var dte = (DTE)Marshal.GetActiveObject("VisualStudio.DTE.10.0");
        var processes = dte.Debugger.LocalProcesses.OfType<Process>();
        return processes.SingleOrDefault(x => x.ProcessID == processID);
    }
