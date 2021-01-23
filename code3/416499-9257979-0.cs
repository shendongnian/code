    public string GetHtmlPageContent(string url)
        {
            HttpWebResponse siteResponse = null;
            HttpWebRequest siteRequest = null;
            string content= string.Empty;
            try
            {
                Uri uri = new Uri(url);
                siteRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                siteResponse = (HttpWebResponse)siteRequest.GetResponse();
                content = GetResponseText(siteResponse);
            }
            catch (WebException we)
            {
                // Log error
            }
            catch (Exception e2)
            {
                // Log error
            }
            return content;
        }
            public string GetResponseText(HttpWebResponse response)
        {
            string responseText = string.Empty;
            if (response == null)
                return string.Empty;
            try
            {
                StreamReader responseReader = new StreamReader(response.GetResponseStream());
                responseText = responseReader.ReadToEnd();
                responseReader.Close();
            }
            catch (Exception ex)
            {
                // Log error
            }
            return responseText;
        }
