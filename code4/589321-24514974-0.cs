    public string ResolveStreamcloud(string url)
    {
        var client = new WebClient();
        var response = client.DownloadString(url);
    
    
        var regexObj = new Regex("<input.*?name=\"(.*?)\".*?value=\"(.*?)\">", RegexOptions.Singleline);
        var matchResults = regexObj.Match(response);
        while (matchResults.Success)
        {
            reqParams.Add(matchResults.Groups[1].Value, matchResults.Groups[2].Value);
            matchResults = matchResults.NextMatch();
        }
    
        Thread.Sleep(10500);
    
        byte[] responsebytes = client.UploadValues(textBox2.Text, "POST", reqParams);
        string responsebody = Encoding.UTF8.GetString(responsebytes);
    
        string resolved = Regex.Match(responsebody, "file: \"(.+?)\",", RegexOptions.Singleline).Groups[1].Value;
    
        if (!String.IsNullOrEmpty(resolved))
        {
            return resolved;
        }
        else
        {
            throw new Exception("File not found!");
        }
    
    }
