    string url = "http://remoteserver.com/getdata.jsp?id=515";
    using (var client = new WebClient())
    {
         client.Encoding = System.Text.Encoding.GetEncoding(1252);
         var result = client.DownloadString(url);
    }
    return result;
