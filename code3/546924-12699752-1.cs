    HttpWebRequest myHttpWebRequest; // ADDED
    Timer timer; // ADDED
    
    private void StartRequest()
    {
            myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.78.221.11/SomeFunc/excpopulatedept");
            RqstState myRequestState = new RqstState();
            myRequestState.request = myHttpWebRequest;
    
            // Start the asynchronous request.
            IAsyncResult result =
                        (IAsyncResult)myHttpWebRequest.BeginGetResponse(new AsyncCallback(RespCallback), myRequestState);
                timer = new Timer(delegate { if (!completed) myHttpWebRequest.Abort(); }, null, waitTime, Timeout.Infinite); // ADDED
    }
    
    //... 
    
    private void ReadCallBack(IAsyncResult asyncResult)
    {
        try
        {
            RqstState myRequestState = (RqstState)asyncResult.AsyncState;
            Stream responseStream = myRequestState.streamResponse;
            int read = responseStream.EndRead(asyncResult);
            // Read the HTML page and then print it to the console.
            if (read > 0)
            {
                myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.BufferRead, 0, read));
                IAsyncResult asynchronousResult = responseStream.BeginRead(myRequestState.BufferRead, 0, 1024, new AsyncCallback(ReadCallBack), myRequestState);
            }
            else
            {
                completed = true; // ADDED
                timer.Dispose();  // ADDED
                if (myRequestState.requestData.Length > 1)
                {
                    string stringContent;
                    stringContent = myRequestState.requestData.ToString();
                    responseStream.Close();
                }
            }
        }
    }
