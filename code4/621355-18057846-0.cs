    //Our generic success callback accepts a stream - to read whatever got sent back from server
    public delegate void RESTSuccessCallback(Stream stream);
    //the generic fail callback accepts a string - possible dynamic /hardcoded error/exception message from client side
    public delegate void RESTErrorCallback(String reason);
     
    public void post(Uri uri,  Dictionary<String, String> post_params, Dictionary<String, String> extra_headers, RESTSuccessCallback success_callback, RESTErrorCallback error_callback)
    {
        HttpWebRequest request = WebRequest.CreateHttp(uri);
        //we could move the content-type into a function argument too.
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
     
        //this might be helpful for APIs that require setting custom headers...
        if (extra_headers != null)
            foreach (String header in extra_headers.Keys)
                try
                {
                    request.Headers[header] = extra_headers[header];
                }
                catch (Exception) { }
     
     
        //we first obtain an input stream to which to write the body of the HTTP POST
        request.BeginGetRequestStream((IAsyncResult result) =>
        {
            HttpWebRequest preq = result.AsyncState as HttpWebRequest;
            if (preq != null)
            {
                Stream postStream = preq.EndGetRequestStream(result);
                
                //allow for dynamic spec of post body
                StringBuilder postParamBuilder = new StringBuilder();
                if (post_params != null)
                    foreach (String key in post_params.Keys)
                        postParamBuilder.Append(String.Format("{0}={1}", key, post_params[key]));
     
                Byte[] byteArray = Encoding.UTF8.GetBytes(postParamBuilder.ToString());
     
                //guess one could just accept a byte[] [via function argument] for arbitrary data types - images, audio,...
                postStream.Write(byteArray, 0, byteArray.Length);
                postStream.Close();
     
     
                //we can then finalize the request...
                preq.BeginGetResponse((IAsyncResult final_result) =>
                {
                    HttpWebRequest req = final_result.AsyncState as HttpWebRequest;
                    if (req != null)
                    {
                        try
                        {
                            //we call the success callback as long as we get a response stream
                            WebResponse response = req.EndGetResponse(final_result);
                            success_callback(response.GetResponseStream());
                        }
                        catch (WebException e)
                        {
                            //otherwise call the error/failure callback
                            error_callback(e.Message);
                            return;
                        }
                    }
                }, preq);
            }
        }, request);            
    }
