            using (var irtProcess = new Process())
            {
                irtProcess.StartInfo.FileName = Server.MapPath("~/Testing/Demo/MyEXE.exe");
                irtProcess.StartInfo.Arguments = String.Format("\"{0}\"", commandFile);
                irtProcess.StartInfo.WorkingDirectory = savePath;
                irtProcess.Start();
                irtProcess.WaitForExit();
            }
