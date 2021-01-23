    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        
              synchronizationContext.Post(new SendOrPostCallback(
               delegate
               {
                   dgUsers.Rows[0].Cells[0].Value = e.Result;
               }), null);
    }
