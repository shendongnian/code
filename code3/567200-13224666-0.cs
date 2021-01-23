    public void MakeHttpWebRequest(string userName)
    {
        string url = "http://www.someforum.com/members/" + userName + ".html";
        var request = (HttpWebRequest)(WebRequest.Create(url));
        var response = request.GetResponse();
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:16.0) Gecko/20100101 Firefox/16.0";
        using (var responseStream = response.GetResponseStream())
        {
            using (var responseStreamReader = new StreamReader(responseStream))
            {
                var serverResponse = responseStreamReader.ReadToEnd();
                int startpoint = serverResponse.IndexOf("Contact Info</span>");
                try
                {
                    string strippedResponse = serverResponse.Remove(0, startpoint);
                    ExtractEmails(strippedResponse);
                }
                catch { }
            }
        }
    }
