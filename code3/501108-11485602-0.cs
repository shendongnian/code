    private void btnSave_Click(object sender, EventArgs e)
    {
        string fileName = this.fileName.Text.Trim();
        byte[] byteArray = Encoding.Unicode.GetBytes(this.fileContent.Text.Trim());
        MemoryStream fileStream = new MemoryStream(byteArray);
          
        LiveConnectClient uploadClient = new LiveConnectClient(App.Current.LiveSession);
        uploadClient.UploadCompleted += new EventHandler<LiveOperationCompletedEventArgs>(uploadClient_UploadCompleted);
        uploadClient.UploadAsync("me/skydrive", fileName, fileStream );
    }
