    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    statusCode = (int)response.StatusCode;
    ActivateCallback(responseCallback, response, url, string.Empty);
    var fieldStatusCode = response.GetType().GetField("m_StatusCode", 
                                                       BindingFlags.Public | 
                                                       BindingFlags.NonPublic | 
                                                       BindingFlags.Instance);
    var statusCodeNew = (HttpStatusCode)409;
    fieldStatusCode.SetValue(response, statusCodeNew);
    string responceBody = "{\"error\":{\"code\":\"AF429\",\"message\":\"Too many requests. Method=GetContents, PublisherId=00000000-0000-0000-0000-000000000000\"}}";
    var propStream = response.GetType().GetField("m_ConnectStream", 
                                                  BindingFlags.Public | 
                                                  BindingFlags.NonPublic | 
                                                  BindingFlags.Instance);
    System.IO.MemoryStream ms = new System.IO.MemoryStream(
                               System.Text.Encoding.UTF8.GetBytes(responceBody));
    propStream.SetValue(response, ms);
    ms.Position = 0;
