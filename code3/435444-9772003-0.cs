    var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
    nameValues.Set("sortBy", "4");
    string url = Request.Url.AbsolutePath;
    string updatedQueryString = "?" + nameValues.ToString();
    Response.Redirect(url + updatedQueryString);
