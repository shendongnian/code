        public static XmlDocument TestRun2(string xsltPath, string docPath, IReport _report)
        {
            var tempFile = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            var x = Process.GetCurrentProcess().MainModule;
            Process p = new Process();
            p.StartInfo.FileName = Path.Combine(Path.GetDirectoryName(x.FileName), "Transform.exe");
            _report.API.WriteLog(p.StartInfo.FileName);
            p.StartInfo.Arguments = string.Format("\"{0}\" \"{1}\" \"{2}\"", xsltPath, docPath, tempFile);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            _report.API.WriteLog("Output from calling Transform.exe");
            _report.API.WriteLog(output);
            if (!File.Exists(tempFile))
            {
                return null;
            }
            var xd = new XmlDocument();
            xd.Load(tempFile);
            return xd;
            
        }
    }
