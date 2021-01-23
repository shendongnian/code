        private void unmapDrive(String strDrive)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "net";
            proc.StartInfo.Arguments = "use " + @strDrive + @" /delete /yes";
            proc.Start();
            proc.WaitForExit();
        }
