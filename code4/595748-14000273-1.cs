       Uri uri = new Uri("http://www.amazon.com/exec/obidos/search-handle-form/102-5194535-6807312");
       string data = "field-keywords=ASP.NET 2.0";
       if (uri.Scheme == Uri.UriSchemeHttp)
       {
           HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
           request.Method = WebRequestMethods.Http.Post;
           request.ContentLength = data.Length;
           request.ContentType = "application/x-www-form-urlencoded";
           StreamWriter writer = new StreamWriter(request.GetRequestStream());
           writer.Write(data);
           writer.Close();
           HttpWebResponse response = (HttpWebResponse)request.GetResponse();
           StreamReader reader = new StreamReader(response.GetResponseStream());
           string tmp = reader.ReadToEnd();
           response.Close();
           Response.Write(tmp);
       }
