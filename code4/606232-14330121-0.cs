      StringBuilder postData = new StringBuilder();
      if (postData ==null)
      {
        postData =new StringBuilder();
      }
      if (postData .Length!=0)
      {
        postData .Append("&");
      }
      postData .Append(key);
      postData .Append("=");
      postData .Append(System.Web.HttpUtility.UrlEncode(dataItem));
