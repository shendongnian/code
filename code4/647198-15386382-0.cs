    public void GetUserList(string url)
    {
      var request = (HttpWebRequest)WebRequest.Create(url);
      var responseStream = request.GetResponse().GetResponseStream();
      if (responseStream != null)
      {
        string response;
        using (var stream = new StreamReader(responseStream))
        {
          response = stream.ReadToEnd();
        }
        response = DelimiterStrings.Aggregate(response, (current, delim) => current.Replace(delim, "\n"));
        foreach (var line in response.Split(DelimiterChars))
        {
          MainWindow.UserList.Add(line);
        }
      }
    }
