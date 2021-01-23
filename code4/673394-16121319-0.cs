    public async Task UploadScreenshot(DateTime? Date = null)
    {
        var uploadTask = Task.Factory.StartNew(() => 
            _ftp.UploadFile(_screenshotLocalFile, date.HasValue 
                    ? _screenshotRemoteFile.Replace("{1}", date.Value.ToString(Helper.StandardTimeFile))                                                                            
                    : _screenshotRemoteFile.Replace("{1}", DateTime.Now.ToString(Helper.StandardTimeFile))));
        return uploadTask;
    }
