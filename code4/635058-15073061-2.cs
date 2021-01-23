    private async void UploadButton_Click(object sender, EventArgs e)
    {
      UploadButton.Enabled = false;
      Cursor = Cursors.WaitCursor;
      try
      {
        // get some info about the input file
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(FileTextBox.Text);
        var task = UploadDocument(fileInfo);
 
        // show start message
        LogText("Starting uploading " + fileInfo.Name);
        LogText("Size : " + fileInfo.Length);
        await task;
        LogText("Done!");
      }
      catch (Exception ex)
      {
        LogText("Exception : " + ex.Message);
        if (ex.InnerException != null) LogText("Inner Exception : " + ex.InnerException.Message);
      }
      finally
      {
        Cursor = Cursors.Default;
        UploadButton.Enabled = true;
      }
    }
    private async Task UploadDocument(System.IO.FileInfo fileInfo)
    {
      // open input stream
      using (System.IO.FileStream stream = new System.IO.FileStream(FileTextBox.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.Read, 4096, true))
      { 
        using (StreamWithProgress uploadStreamWithProgress = new StreamWithProgress(stream))
        {
          uploadStreamWithProgress.ProgressChanged += uploadStreamWithProgress_ProgressChanged;
          // start service client
          FileTransferWCF.FileTransferServiceClient client = new FileTransferWCF.FileTransferServiceClient();
          // upload file
          await client.UploadFileAsync(fileInfo.Name, fileInfo.Length, uploadStreamWithProgress);
          // close service client
          client.Close();
        }
      }
    }
    void uploadStreamWithProgress_ProgressChanged(object sender, StreamWithProgress.ProgressChangedEventArgs e)
    {
      if (e.Length != 0)
        progressBar1.Value = (int)(e.BytesRead * 100 / e.Length);
    }
