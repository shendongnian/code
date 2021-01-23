    public Stream GetSampleMethod(string strUserName){
      //Initialization code here
      //Begin downloading blob
      BlobStream bStream = blob.OpenRead();
      //Set response headers. Note the blob.Properties collection is not populated until you call OpenRead()
      WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", "attachment; filename="+strUserName + ".txt");
      WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
      WebOperationContext.Current.OutgoingResponse.ContentLength = blob.Properties.Length;
        
      return bStream;
    }
    
