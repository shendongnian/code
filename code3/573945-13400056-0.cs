    foreach(string fileName in chunkFiles)
            {
                p = GenerateProcessInstance();
                p.StartInfo.Arguments = string.Format("{0} {1} false {2}", fileName, Id, logName);
                p.Exited += new EventHandler(p_Exited);
                p.Start();
                
            }
    protected void p_Exited(object sender, EventArgs e) {
      var p = (Process)sender;
      // Handle p.ExitCode
    }
