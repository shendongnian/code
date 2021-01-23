            using (var proc = new Process())
            {
                proc.StartInfo.FileName = Server.MapPath("~/Testing/Demo/MyEXE.exe");
                proc.StartInfo.Arguments = String.Format("\"{0}\"", commandFile);
                proc.StartInfo.WorkingDirectory = savePath;
                proc.Start();
                proc.WaitForExit();
            }
