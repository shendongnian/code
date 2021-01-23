    private void processWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
         string code = DoLongWorkAndReturnCode();
         e.Result = code;
    }
    private void processWorkers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (code != 0)
        {
            MessageBox.Show("Error!");
            EnableAllButtons(); // this is defined in the other thread and it's where i run into the error.
        }
        else
        {
              doAnotherLongProcessAndReturnCodesBackgroundWorker.RunWorkerAsync(); 
        }
    }
