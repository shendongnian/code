    protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        //Fired on the server side when the file successfully uploaded 
        if (AsyncFileUpload1.HasFile)
        {            
            _strFilePath = AppDomain.CurrentDomain.BaseDirectory + "Uploads\\" + AsyncFileUpload1.FileName;
            AsyncFileUpload1.SaveAs(_strFilePath);
            Label1.Text = "Received " + AsyncFileUpload1.FileName + " Content Type " + AsyncFileUpload1.PostedFile.ContentType;
            PlayUploadedFile();
        }
    }
    private void PlayUploadedFile()
    {
        //Here is my Code
        #region Media Player initial settings
        MediaPlayer1.AutoPlay = true;
        MediaPlayer1.ScaleMode = System.Web.UI.SilverlightControls.ScaleMode.Zoom;
        MediaPlayer1.MediaSource = _strFilePath;
        MediaPlayer1.MediaSkinSource = "~/skin/Custom.xaml";
        #endregion
    }
    protected void AsyncFileUpload1_UploadedFileError(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        Label1.Text = "Error!!";
        //Fired on the server side when the loaded file is corrupted 
        //Display some error message here 
    }
