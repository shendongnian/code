        void exportRegistry(string strKey, string filepath)
        {
            try
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo.FileName = "reg.exe";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.Arguments = "export \"" + strKey + "\" \"" + filepath + "\" /y";
                    proc.Start();
                    string stdout = proc.StandardOutput.ReadToEnd();
                    string stderr = proc.StandardError.ReadToEnd();
                    if (!String.IsNullOrWhiteSpace(stdout)) GTLogger.LogInfo("Exported registry stdout: " + stdout) ;
                    if (!String.IsNullOrWhiteSpace(stderr)) GTLogger.LogError(HRESULT.E_FAIL, "Exported registry stderr: " + stderr) ;
                    proc.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                GTLogger.LogError(ex, "Exception thrown exporting registry");
            }
        }
