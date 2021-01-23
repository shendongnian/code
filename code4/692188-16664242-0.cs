                // using some uri
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                // doesn't need ContentType for GET method
                request.CookieContainer = new CookieContainer();
                request.BeginGetResponse(getResponse, request);
----------
 
   
     private void getResponse(IAsyncResult result)
                {
                    HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    CookieCollection cookies = response.Cookies;
                    foreach (Cookie c in cookies)
                    {
                        if (c.Name == "JSESSIONID")
                           // do, whatever you want to
                            MessageBox.Show(c.Value);
                    }
                }
