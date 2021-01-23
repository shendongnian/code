    void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
            if (e.Cancelled)
           {
               lblStatus2.Text = "Status: Stopped";
               cmdStopRun.Enabled = false;
           }
           // Check to see if an error occurred in the background process.
           else if (e.Error != null)
           {
               lblStatus2.Text = "Fatal Error while processing.";
           }
           else
           {
               // Everything completed normally.
               //CurrentState state = (CurrentState)e.UserState;
               lblStatus2.Text = "Status: Finished";            
           }
           
       }
        
