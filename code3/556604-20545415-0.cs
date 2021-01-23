      catch (WebException ex)
           {                     
             using (WebResponse webResponse = ex.Response)
                  {
                    HttpWebResponse httpResponse = (HttpWebResponse)webResponse;
                    using (Stream data = webResponse.GetResponseStream())
                    using (var reader = new StreamReader(data))
                        {
                          string string = reader.ReadToEnd();
                               
                          }
                  }
              }
