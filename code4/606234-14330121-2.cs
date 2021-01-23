      foreach(KeyValuePair<string, string> pair in items)
      {      
        StringBuilder postData = new StringBuilder();
        if (postData .Length!=0)
        {
           postData .Append("&");
        }
        postData .Append(pair.Key);
        postData .Append("=");
        postData .Append(System.Web.HttpUtility.UrlEncode(pair.Value));
      }
