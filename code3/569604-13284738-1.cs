    BackgroundWorker bw = new BackgroundWorker();
              if (bw.IsBusy != true)
              {
                  bw.RunWorkerAsync();
                 
              }
    
              private void bw_DoWork(object sender, DoWorkEventArgs e)
              {
                  // Run your while loop here and return result.
                  result = // your time consuming function (while loop)
              }
              
              // when you click on some cancel button  
               bw.CancelAsync();
