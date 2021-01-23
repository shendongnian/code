        StringCollection values = new StringCollection();
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "openfiles.exe",
                Arguments = "/query /FO CSV /v",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            }
        };
        proc.Start();
              
        proc.OutputDataReceived += (s,e) => {
            lock (values)
            {
                values.Add(e.Data);
            }
        };
        proc.ErrorDataReceived += (s,e) => {
            lock (values)
            {
                values.Add("! > " + e.Data);
            }
        };
    
        proc.BeginErrorReadLine();
        proc.BeginOutputReadLine();
    
        proc.WaitForExit();
        foreach (string sline in values)
            MessageBox.Show(sline);
            
