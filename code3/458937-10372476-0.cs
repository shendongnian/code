     public class WebRequestWrapper
     {
          private HttpWebRequest _request;
          public WebRequestWrapper(HttpWebRequest request)
          {
              this._request = request;
          }
          public string DownloadText()
          {
              using (var response = (HttpWebResponse)this._request.GetResponse())
              using (var reader = new StreamReader(response.GetResponseStream()))
              {
                  return reader.ReadToEnd();
              }
          }
     }
