    /// <summary>
    /// Chunk the file and upload
    /// </summary>
    /// <param name="filename"></param>
    private void UploadVideo(string filename)
    {
        #region Vars
        const int chunkSize = 512000;
        byte[] bytes = null;
        int startIndex, endIndex, length, totalChunks;           
    
        WS.UploadRequest objRequest = new WS.UploadRequest();            
        #endregion
    
        try
        {
            if (File.Exists(filename))
            {
                using (WS.UploadService objService = new WS.UploadService())
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        //// Calculate total chunks to be sent to service
                        totalChunks = (int)Math.Ceiling((double)fs.Length / chunkSize);
    
                        //// Set up Upload request object
                        objRequest.FileName = filename;
                        objRequest.FileSize = fs.Length;
                                
                        for (int i = 0; i < totalChunks; i++)
                        {
                            startIndex = i * chunkSize;
                            endIndex = (int)(startIndex + chunkSize > fs.Length ? fs.Length : startIndex + chunkSize);
                            length = endIndex - startIndex;
                            bytes = new byte[length];
    
                            //// Read bytes from file, and send upload request
                            fs.Read(bytes, 0, bytes.Length);
                            objRequest.FileBytes = bytes;
                            objService.UploadVideo(objRequest);
                        }
                    }
    
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format("Error- {0}", ex.Message));
        }
    
