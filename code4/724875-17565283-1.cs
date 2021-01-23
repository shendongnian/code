       [OperationContract()]
       [WebInvoke(UriTemplate = "/RESTJson_Sample1_Sample1Add?A=a&B=b&C=c", Method = "POST",  
         RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,   
         BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int RESTJson_Sample1_Sample1Add(Int32 a, Int32 b, Int32 c);
           var httpWebRequest = (HttpWebRequest)WebRequest.Create("/RESTJson_Sample1_Sample1Add?A=a&B=b&C=c");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = methodType;//POST/GET
            string responseText = "";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(body);//any parameter
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseText = streamReader.ReadToEnd();
            }
            return responseText;
