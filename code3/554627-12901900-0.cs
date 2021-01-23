    private void ReadStreamAsyncImpl(Stream stream)
        {
            chunk = new byte[chunkSize];
            stream.BeginRead(chunk, 0, chunkSize, new AsyncCallback(BeginReadCallback), stream);
        }
    
        private void BeginReadCallback(IAsyncResult ar)
        {
            Stream stream = ar.AsyncState as Stream;
            int bytesRead = stream.EndRead(ar);
            StreamContentsAsString += StreamEncoding.GetString(chunk, 0, bytesRead);
    
            if (bytesRead < chunkSize) {
                // Finished
                isOperationInProgress = false;
                stream.Close();
                if (null != ReadStreamCompleted) {
                    ReadStreamCompleted(this, new EventArgs());
                }
            } else {
                ReadStreamAsyncImpl(stream);
            }
        }
