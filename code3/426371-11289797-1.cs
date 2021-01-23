    public static bool SessionRequest(Fiddler.Session oS, ref string htmlContent, string requestMethod)
        {
            try
            {
                WebRequest request = WebRequest.Create(oS.fullUrl);
                if (oS != null && oS.oRequest.headers != null && oS.oRequest.headers.Count() > 0)
                {
                    NameValueCollection coll = new NameValueCollection();
                    request.Headers = new WebHeaderCollection();
                    foreach (Fiddler.HTTPHeaderItem rh in oS.oRequest.headers)
                    {
                        if (rh.Name.Contains("Cookie"))
                        {
                            ((HttpWebRequest)request).CookieContainer = new CookieContainer();
                            string[] cookies = UtilitiesScreenScrapper.UtilityMethods.SplitString(rh.Value, ";");
                            if (cookies != null && cookies.Length > 0)
                            {
                                foreach (string c in cookies)
                                {
                                    string[] cookie = UtilitiesScreenScrapper.UtilityMethods.SplitString(c, "=");
                                    if (cookie != null && cookie.Length > 0)
                                    {
                                        cookie[0] = cookie[0].Replace(" ", "%");
                                        cookie[1] = cookie[1].Replace(" ", "%");
                                        ((HttpWebRequest)request).CookieContainer.Add(new Uri(oS.fullUrl), new Cookie(cookie[0].Trim(), cookie[1].Trim()));
                                    }
                                }
                            }
                            else
                            {
                                string[] cookie = UtilitiesScreenScrapper.UtilityMethods.SplitString(rh.Value, "=");
                                if (cookie != null && cookie.Length > 0)
                                {
                                    ((HttpWebRequest)request).CookieContainer.Add(new Uri(oS.url), new Cookie(cookie[0], cookie[1]));
                                }
                            }
                        }
                        else if (rh.Name.Contains("User-Agent"))
                        {
                            ((HttpWebRequest)request).UserAgent = rh.Value;
                        }
                        else if (rh.Name.Contains("Host"))
                        {
                            ((HttpWebRequest)request).Host = "www." + oS.host;
                        }
                        else if (rh.Name.Equals("Accept"))
                        {
                            ((HttpWebRequest)request).Accept = rh.Value;
                        }
                        else if (rh.Name.Contains("Content-Type"))
                        {
                            ((HttpWebRequest)request).ContentType = rh.Value;
                        }
                        else if (rh.Name.Contains("Content-Length"))
                        {
                            ((HttpWebRequest)request).ContentLength = oS.RequestBody.Length;
                        }
                        else if (rh.Name.Contains("Connection"))
                        {
                            //((HttpWebRequest)request).Connection = rh.Value;
                        }
                        else if (rh.Name.Equals("Referer"))
                        {
                            ((HttpWebRequest)request).Referer = oS.host;
                        }
                        else
                        {
                            ((HttpWebRequest)request).Headers.Add(rh.Name + ":");
                            ((HttpWebRequest)request).Headers[rh.Name] = rh.Value;
                        }
                    }
                    ((HttpWebRequest)request).Headers.Add("Conneciton:");
                    ((HttpWebRequest)request).Headers["Conneciton"] = "keep-alive";
                    ((HttpWebRequest)request).AllowAutoRedirect = true;
                    Stream dataStream;
                    if (oS.RequestBody.Length > 0)
                    {
                        request.Method = "POST";
                        // Get the request stream.
                        dataStream = request.GetRequestStream();
                        // Write the data to the request stream.
                        dataStream.Write(oS.RequestBody, 0, oS.RequestBody.Length);
                        // Close the Stream object.
                        dataStream.Close();
                    }
                    else
                    {
                        request.Method = "GET";
                    }
                    //string postData = string.Empty;
                    //byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    // Set the ContentType property of the WebRequest.
                    //request.ContentType = "application/x-www-form-urlencoded";
                    // Get the response.
                    WebResponse response = request.GetResponse();
                    //resp = response;
                    // Display the status.
                    Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                    // Get the stream containing content returned by the server.
                    dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    //Console.WriteLine(responseFromServer);
                    htmlContent = responseFromServer;
                    // Clean up the streams.
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return false;
        }
