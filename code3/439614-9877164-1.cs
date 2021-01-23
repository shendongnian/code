    private static void GetLoginResponseCallback(IAsyncResult asynchronousResult)
    {
    //MY UPDATE 
        //Unbox your object state with the current thread context
        object[] boxedItems = asynchronousResult.AsyncState as object[];
        HttpWebRequest request = boxedItems[0] as HttpWebRequest;
        SynchronizationContext context = boxedItems[1] as SynchronizationContext;
        // End the operation
        HttpWebResponse response =  
            (HttpWebResponse)request.EndGetResponse(asynchronousResult);
        Stream streamResponse = response.GetResponseStream();
        StreamReader streamRead = new StreamReader(streamResponse);
        string responseString = streamRead.ReadToEnd();
        Console.WriteLine(responseString);
    //MY UPDATE
        //Make an asynchronous call back onto the main UI thread 
        //(context.Send for a synchronous call)
        //Let me know if I need to elaborate further on this piece
        context.Post(UIMethodToCall, StateObjectThatUIWillActOn);
        // Close the stream object
        streamResponse.Close();
        streamRead.Close();
        response.Close();
    }
