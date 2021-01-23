    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
       while (condition)
       {
          if (pauseWorker == true)
          {
             while (pauseWorker == true)
             {
                if (pauseWorker == false) break;
             }
          }
          else
          {
             //continue process... your code here
          }
       }
    }
    
    private void frmCmsnDownload_FormClosing(object sender, FormClosingEventArgs e)
    {
       if (bgWorker.IsBusy)
       {
          pauseWorker = true; //this will trigger the dowork event to loop that
                              //checks if pauseWorker is set to false
          DiaglogResult x = MessageBox.Show("You are about cancel the process", "Close", MessageBoxButtons.YesNo);
          if (x == DialogResult.Yes) bgWorker.CancelAsync();
          else 
          { 
             e.Cancel = true; 
             pauseWorker = false; //if the user click no
                                  //the do work will continue the process
             return;
          }
       }
    }
