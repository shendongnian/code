                            // working with some uri
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                            request.Method = "GET";
                            request.CookieContainer = new CookieContainer();
                            request.BeginGetResponse(asynchronousResult =>
                                {
                                    try
                                    {
                                        using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult))
                                        {
                                            CookieCollection cookies = response.Cookies;
                                            foreach (Cookie c in cookies)
                                            {
                                                if (c.Name == "JSESSIONID")
                                                    // do, whatever you want
                                            }
                                            response.Close();
                                        }
    
                                       
                                    catch (Exception e)
                                    {
                                        // handling exception somehow
                                    }
                                }
                            , request);
