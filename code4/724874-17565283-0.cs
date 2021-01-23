           var httpWebRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
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
