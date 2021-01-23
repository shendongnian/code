    string GetWebPage(string address)
    {
        string responseText;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
            {
                responseText = responseStream.ReadToEnd();
            }
        }
        return responseText;
    }
