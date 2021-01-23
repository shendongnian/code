    public static string PrinterDriverName = "MyPrinter.INF";
    public static string portOutputFileName = "nul:";
    /// <summary>
    /// Installs a printer and driver from an INF file, setting the 
    /// port to portOutputFileName ('nul:' in this case)
    /// </summary>
    private static void CreatePrinterPrintUI()
    {
      string sCommand = String.Format(@"rundll32 printui,PrintUIEntry /if /K /m '{0}' /n '{0}' /r '{2}' /f '{1}'"
        ,PrinterDriverName,Path.Combine(Application.StartupPath,PrinterDriverInf)
        ,portOutputFileName).Replace("'","\""); //it fails on single quotes
      execCmd(sCommand);
    }
    public static void execCmd(string _sCmd)
    {
      try
      {
        System.Diagnostics.ProcessStartInfo p = new ProcessStartInfo("cmd", "/c " + _sCmd);
        p.RedirectStandardOutput = true;
        p.UseShellExecute = false;
        p.CreateNoWindow = true;
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo = p;
        proc.Start();
        string sResult = proc.StandardOutput.ReadToEnd();
        Console.WriteLine(sResult);
      }
      catch (Exception e)
      {
        sErr += e.ToString();
      }
    }
