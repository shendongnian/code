    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(WebRequestPath);
                    myReq.Method = "POST";
                    myReq.ContentType = "text/xml; encoding=utf-8";
                    myReq.Timeout = 180000;
                    myReq.KeepAlive = true;
                    myReq.Headers.Add("SOAPAction", "http://tempuri.org/AmaliPostData");
                    myReq.Accept = "gzip,deflate";
                    byte[] PostData = Encoding.UTF8.GetBytes(xmlString.Trim());
                    myReq.UseDefaultCredentials = false;
                    NetworkCredential cred;
                    cred = new NetworkCredential(WebRequestUname, WebRequestPassword);
                    myReq.Credentials = cred;
                    myReq.Host = WebRequestHost.Trim();
                    myReq.Credentials = new System.Net.NetworkCredential(WebRequestUname, WebRequestPassword);
                    myReq.PreAuthenticate = true;
                    string SetProxy;
                    SetProxy = WebRequestProxy; // something like this... "10.2.0.1:8080";
                    var proxyObject = new WebProxy(SetProxy);
                    myReq.Proxy = proxyObject;
                    try
                    {
                        var writer = myReq.GetRequestStream();
                        writer.Write(PostData, 0, PostData.Length);
                        writer.Close();
      }
                    catch (Exception ex)
                    {
                        WriteLog(" Writer Exception " + ex.Message + ex.InnerException + " host : " + myReq.Host);
                    }
    
                    HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
                    string resp;
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(responseStream))
                        {
                            resp = sr.ReadToEnd();
                        }
                    }
