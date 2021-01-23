    try
                            {
                                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:64519/TestPage.aspx");
                                webRequest.Method = "GET";
                                string responseData = string.Empty;
                                HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();
                                using (StreamReader responseReader = new StreamReader(httpResponse.GetResponseStream()))
                                {
                                    responseData = responseReader.ReadToEnd();
                                }
                            }
                            catch (System.Net.WebException ex)
                            {
                              //Code - If does not Exist  
                            }
