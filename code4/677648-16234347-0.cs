    public static string StartCmdProcess(string[] cmd)
    {
        System.Diagnostics.Process p = new System.Diagnostics.Process
        {
            StartInfo =
            {
                FileName = cmd[0],
                Arguments = cmd.Length>1?cmd[1]:"",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            }
         };
         p.Start();
         p.StandardInput.AutoFlush = true;
         for (int i = 0; i < cmd.Length; i++)
         {
             p.StandardInput.WriteLine(cmd[i].ToString());
         }
         p.StandardInput.WriteLine("exit");
         string strRst = p.StandardOutput.ReadToEnd();
         p.WaitForExit();
         p.Close();
         return strRst;
     } 
