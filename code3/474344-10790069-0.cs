        private static AsyncCallback GetResponseCallback(string xmlName)
         {
            return (IAsyncResult asynchronousResult) =>{
            HttpWebRequest httpRequest = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the operation
            HttpWebResponse response = (HttpWebResponse)httpRequest.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseStream = streamRead.ReadToEnd();
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var istream = new IsolatedStorageFileStream(@"tmp" + xmlName + ".xml", FileMode.OpenOrCreate, store))
                {
                    using (var sw = new StreamWriter(istream))
                    {
                        sw.Write(responseStream);
                    }
                }
            }
            // Close the stream object
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse
            response.Close();
          }
        }
