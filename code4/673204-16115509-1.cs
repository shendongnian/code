    void ResponseCallback(IAsyncResult ir)
    {
        try
        {
            var request = (HttpWebRequest)ir.AsyncState;
            // you'll want exception handling here
            using (var response = (HttpWebResponse)request.EndGetResponse(ir))
            {
                // process the response here.
            }
        }
        finally
        {
            // release the semaphore so that another request can be made
            _requestSemaphore.Release();
        }
    }
