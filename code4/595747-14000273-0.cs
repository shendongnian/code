     Uri uri = new Uri("http://www.microsoft.com/default.aspx");
     if(uri.Scheme = Uri.UriSchemeHttp) 
     {
         HttpWebRequest request = HttpWebRequest.Create(uri);
         request.Method = WebRequestMethods.Http.Get;
         HttpWebResponse response = request.GetResponse();
         StreamReader reader = new StreamReader(response.GetResponseStream());
         string  tmp = reader.ReadToEnd();
         response.Close();
         Response.Write(tmp);
      }
