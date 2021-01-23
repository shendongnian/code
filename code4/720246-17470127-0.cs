    var request = new HttpRequestMessage(HttpMethod.Post, uri);
    string strData = new JavaScriptSerializer().Serialize(jsonObject);
    var content = new StringContent(strData, Encoding.UTF8, "application/json");
    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
    request.Content = content;
