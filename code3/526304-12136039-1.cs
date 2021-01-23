    if (IsPostBack)
    {
        if (myFile.PostedFile != null)
        {
            // File was sent
            var postedFile = myFile.PostedFile;
            int dataLength = postedFile.ContentLength;
            byte[] myData = new byte[dataLength];
            postedFile.InputStream.Read(myData, 0, dataLength);
        }
        else
        {
            // No file was sent
    
        }
    }
 
