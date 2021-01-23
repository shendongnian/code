    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
    request.Method = WebRequestMethods.Http.Post;
    request.ContentLength = DataToPost.Length;
    request.ContentType = "application/x-www-form-urlencoded";
    StreamWriter writer = new StreamWriter(request.GetRequestStream());
    writer.Write(DataToPost);
    writer.Close();
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    StreamReader reader = new StreamReader(response.GetResponseStream());
