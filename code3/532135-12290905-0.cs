    Process myProcess;
    
    private void btnViewErrorLogFile_Click(object sender, EventArgs e)
    {
        myProcess.Start(AppVars.ErrorLogFilePath);
    }
    
    private void doSomething()
    {
        if (!myProcess.HasExited)
        {
          myProcess.CloseMainWindow();
          myProcess.Close();
        }
        // Do whatever you need with the file
    }
