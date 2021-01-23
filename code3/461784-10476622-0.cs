    public void MergeFiles(string strFile)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = Server.MapPath("~/app.bat");
                p.Start();
                p.WaitForExit();
                p.Dispose();
            }
