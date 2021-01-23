    StringBuilder postData = new StringBuilder();
    postData.Append("username=" + HttpUtility.UrlEncode(uname) + "&");
    postData.Append("password=" + HttpUtility.UrlEncode(pword) + "&");
    postData.Append("url_success=" + HttpUtility.UrlEncode(urlSuccess) + "&");
    postData.Append("url_failed=" + HttpUtility.UrlEncode(urlFailed));
