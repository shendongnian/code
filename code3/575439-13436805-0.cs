    private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
    {
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
        // End the operation
        using (Stream postStream = request.EndGetRequestStream(asynchronousResult))
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(message);
            // Write to the request stream.
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();
        }
        // Start the asynchronous operation to get the response
        request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
    }
    private void GetResponseCallback(IAsyncResult asynchronousResult)
    {
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
        // End the operation
        string responseString;
        using (HttpWebResponse response = (HttpWebResponse) request.EndGetResponse(asynchronousResult))
        {
            using (Stream streamResponse = response.GetResponseStream())
            {
                using (StreamReader streamRead = new StreamReader(streamResponse))
                {
                    responseString = streamRead.ReadToEnd();
                    Console.WriteLine(responseString);
                }
            }
        }
        allDone.Set();
        MessageReceived(responseString);
    }
