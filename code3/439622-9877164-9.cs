    private static void GetLoginResponseCallback(IAsyncResult asynchronousResult)
    {
    //MY UPDATE 
        //Unbox your object state with the current thread context
        object[] boxedItems = asynchronousResult.AsyncState as object[];
        HttpWebRequest request = boxedItems[0] as HttpWebRequest;
        SynchronizationContext context = boxedItems[1] as SynchronizationContext;
        // End the operation
        using(HttpWebResponse response =  
            (HttpWebResponse)request.EndGetResponse(asynchronousResult))
        {
            using(Stream streamResponse = response.GetResponseStream())
            {
                using(StreamReader streamRead = new StreamReader(streamResponse))
                {
                    string responseString = streamRead.ReadToEnd();
                    Console.WriteLine(responseString);
    //MY UPDATE
                    //Make an asynchronous call back onto the main UI thread 
                    //(context.Send for a synchronous call)
                    //Pass responseString as your method parameter 
                    //If you have more than one object, you will have to box again
                    context.Post(UIMethodToCall, responseString);
                }
            }
        }
    }
