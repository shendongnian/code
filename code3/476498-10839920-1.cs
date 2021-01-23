    string getHtml(string url) {
       HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
       request.Method = "GET";
       HttpWebResponse response = (HttpWebResponse)request.GetResponse();
       StreamReader source = new StreamReader(myWebResponse.GetResponseStream());
       string pageSourceStr = string.Empty;
       pageSourceStr= source.ReadToEnd();
       response.Close();
       return pageSourceStr;
    }
