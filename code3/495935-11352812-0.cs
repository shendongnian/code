    string url = "http://sitename/folder1/someweb.dll?RetrieveTestByDateTime&PatientID=1234&param2=blah blah blah";
    var queryString = uri.Query;
    NameValueCollection query = HttpUtility.ParseQueryString(queryString)
    query["PatientID"] = string.Concat(HttpUtility.UrlEncode(PatientIDValue), HttpUtility.UrlEncode(param2Value));
     
    // Rebuild the querystring
    queryString = "?" + string.Join("&", Array.ConvertAll(query.AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(query[key]))));
