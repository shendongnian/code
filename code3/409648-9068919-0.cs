        private string GetWebPage()
        {
            string pageSource;
            string getUrl = "http://index.htm";
            WebRequest getRequest = WebRequest.Create(getUrl);
            WebResponse getResponse = getRequest.GetResponse();
            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                pageSource = sr.ReadToEnd();
                sourceResult = pageSource;
            }
            return sourceResult;
        }
