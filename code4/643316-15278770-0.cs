    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "/tmp/bash.sh";
        psi.UseShellExecute = false;
        psi.RedirectStandardOutput = true;
        psi.Arguments = "test";
        Process p = Process.Start(psi);
        string strOutput = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        Console.WriteLine(strOutput);
    }
