    using (Process outerProc = new Process())
    {
        outerProc.StartInfo.FileName = "something1.exe";
        outerProc.StartInfo.UseShellExecute = false;
        outerProc.StartInfo.RedirectStandardOutput = true;
        outerProc.Start();
        string str = outerProc.StandardOutput.ReadToEnd();
        using(Process innerProc = new Process())
        {
            innerProc.StartInfo.FileName = "something2.exe";
            innerProc.StartInfo.UseShellExecute = false;
            innerProc.StartInfo.RedirectStandardInput = true;
            innerProc.Start();
            innerProc.StandardInput.Write(str);
            innerProc.WaitForExit();
        }
        outerProc.WaitForExit();
    }
