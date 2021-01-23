           pProcess.StartInfo.Arguments = "--options=none --style=ansi --recursive  *.h *.cpp";
           pProcess.StartInfo.UseShellExecute = false;
           pProcess.StartInfo.RedirectStandardOutput = true;
           pProcess.StartInfo.RedirectStandardError = true;
           pProcess.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(target_path);
           try
           {
               pProcess.Start();
               string strOutput = pProcess.StandardOutput.ReadToEnd();
               string strError = pProcess.StandardError.ReadToEnd();
               pProcess.WaitForExit();
               
           }
           catch { }
       }
'
