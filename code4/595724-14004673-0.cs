    public string fileGetContents(string url)
        {
            string text = "";
            var webRequest = HttpWebRequest.Create(url);
            IAsyncResult asyncResult = null; 
            asyncResult = webRequest.BeginGetResponse(
                state => 
                { 
                    var response = webRequest.EndGetResponse(asyncResult); 
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        text = sr.ReadToEnd();
                    } 
                }, null
                );
            return text;
        }
