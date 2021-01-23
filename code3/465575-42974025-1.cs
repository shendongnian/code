    private static void CreateZip(string path, string zipFilename, Action<int> onProgress) {
        Regex REX_SevenZipStatus = new Regex(@"(?<p>[0-9]+)%");
        Process p = new Process();
        p.StartInfo.FileName = "7za.exe";
        p.StartInfo.Arguments = string.Format("a -y -r -bsp1 -bse1 -bso1 {0} {1}", 
            zipFilename, path);
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.OutputDataReceived += (sender, e) => {
            if (onProgress != null) {
                Match m = REX_SevenZipStatus.Match(e.Data ?? "");
                if (m != null && m.Success) {
                    int procent = int.Parse(m.Groups["p"].Value);
                    onProgress(procent);
                }
            }
        };
        
        p.Start();
        p.BeginOutputReadLine();
        p.WaitForExit();
    }
