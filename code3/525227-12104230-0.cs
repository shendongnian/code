    // add a BackGroundWorker bwLoadData to your form
    private void YOURBUTTON_Click(object sender, EventArgs e)
    {
         PictureBox1.Visible = true;
         bwLoadData.RunWorkerAsync();
    }
    private void bwLoadData_DoWork(object sender, DoWorkEventArgs e)
    {
         // access your db, execute storedProcedue and store result to
         e.Result = YOUR_DATASET_RECORDS_OR_ANYTHING_ELSE;
    }
    private void bwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
         if (e.Result != null)
         {
              // e.g. show data on form
         } else {
              // e.g. error message
         }
    }
