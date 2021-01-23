        private void mapDrive(String strDrive, String strLocation, string strUser, string strPassword)
        {
            System.Diagnostics.Process proc  = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "net";
            proc.StartInfo.Arguments = "use " + @strDrive + " " + @strLocation + " " + @" /USER:" + @strUser + " " + @strPassword;
            proc.Start();
            proc.WaitForExit();
        }
