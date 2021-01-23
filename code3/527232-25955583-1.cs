    private  void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
       {
          
           DateTime LastCrawlTime;
           try
           {
             LastCrawlTime = Convert.ToDateTime(txtLastRunTime.Text);
            if (lblStatus2.Text != "Status: Running" || (!cmdRunNow.Enabled && cmdStopRun.Enabled)) // run is not currently running or cmdRunNow clicked
            {
                //lblStatus2.Text = "Status: Running";
                GetUpdated(LastCrawlTime,e);
            }
           }
           catch (Exception Ex)
           {
               MessageBox.Show(Ex.Message);
           }
           
       }
