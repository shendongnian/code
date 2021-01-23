    private string GetHtmlFromUrl(string url)
    {
        string html = "";
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        // get the response stream.
        //Stream responseStream = response.GetResponseStream();
        // use a stream reader that understands UTF8
        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        html = reader.ReadToEnd();
        // close the reader
        reader.Close();
        response.Close();
        return html;//return content html
    }
