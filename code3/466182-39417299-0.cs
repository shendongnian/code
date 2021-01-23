    httpWebRequest = (HttpWebRequest)WebRequest.Create(RequestURL);
    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Accept = "application/json";
                    httpWebRequest.Method = "POST";
    String username = "UserName";
    String password = "passw0rd";
    String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
    httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
     using (StreamWriter sw = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{" +
                                        "\"user\":[ \"" + user + "\"] " +
                                        "}";
                        sw.Write(json);
                        sw.Flush();
                        sw.Close();
                    }
    using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                    {
                        //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var responseText = streamReader.ReadToEnd();
                            //Now you have your response.
                            //or false depending on information in the response
                        }
                        httpResponse.Close();
                    }
