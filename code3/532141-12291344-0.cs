    Process errorLogFileProcess;
    
    private void btnViewErrorLogFile_Click(object sender, EventArgs e)
    {
        if (errorLogFileProcess != null)
        {
            // Process was launched previously; check if exited.
            if (!errorLogFileProcess.HasExited)
            {
                throw new Exception("Can't launch until first one closed.");
            }
        }
        errorLogFileProcess = Process.Start(AppVars.ErrorLogFilePath);
    }
