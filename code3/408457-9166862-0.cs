    //c:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\PublicAssemblies\EnvDTE.dll
    using Process = EnvDTE.Process;
    System.Diagnostics.Process p = new System.Diagnostics.Process();
    p.StartInfo.FileName = System.AppDomain.CurrentDomain.BaseDirectory + @"\YourProcess.exe";
    //Start the process
    p.Start();
    //Wait for process init
    System.Threading.Thread.Sleep(1000);
    
    bool attached = false;
    //did not find a better solution for this(since it's not super reliable)
    for (int i = 0; i < 5; i++)
    {
        if (attached)
        {
            break;
        }
        try
        {
            EnvDTE.DTE dte2 = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
            EnvDTE.Debugger debugger = dte2.Debugger;
            foreach (Process program in debugger.LocalProcesses)
            {
                if (program.Name.Contains("YouProcess.exe"))
                {
                    program.Attach();
                    attached = true;
                }
            }
        }
        catch (Exception ex)
        {
            //handle execption...
        }
    }
