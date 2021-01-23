    private void pushMessageSample(string pushedMessage)
    {
    String appid="xxxx-xxxxxxxxxxxxxxxxxxxxxxxxxx";
    String password = "xxxxxx";
    String deliverbefore = DateTime.UtcNow.AddMinutes(5).ToString("s",System.Globalization.CultureInfo.InvariantCulture) + "Z";
    String pushPin = "xxxxxxxx";
    String Boundary = "mPsbVQo0a68eIL3OAxnm";
    
    StringBuilder dataToSend = new StringBuilder();
    
    dataToSend.AppendLine("--" + Boundary);
    dataToSend.AppendLine("Content-Type: application/xml; charset=UTF-8");
    dataToSend.AppendLine("");
    dataToSend.AppendLine("<?xml version=\"1.0\"?>");
    dataToSend.AppendLine("<!DOCTYPE pap PUBLIC \"-//WAPFORUM//DTD PAP 2.1//EN\" \"http://www.openmobilealliance.org/tech/DTD/pap_2.1.dtd\">");
    dataToSend.AppendLine("<pap>");
    string myPushId = DateTime.Now.ToFileTime().ToString();
    dataToSend.AppendLine("<push-message push-id=" + (char)34 + myPushId + (char)34 + " deliver-before-timestamp=" +
    (char)34 + deliverbefore + (char)34 + " source-reference=" + (char)34 + appid + (char)34 + ">");
    //dataToSend.AppendLine("<push-message push-id=\"" + myPushId + "\" source-reference=\"" + appid + "\">");
    dataToSend.AppendLine("<address address-value=\"" + pushPin + "\"/>");
    dataToSend.AppendLine("<quality-of-service delivery-method=\"unconfirmed\"/>");
    dataToSend.AppendLine("</push-message>");
    dataToSend.AppendLine("</pap>");
    dataToSend.AppendLine("--" + Boundary);
    dataToSend.AppendLine("Content-Type: text/plain");
    dataToSend.AppendLine("Push-Message-ID: " + myPushId);
    dataToSend.AppendLine("");
    dataToSend.AppendLine(pushedMessage);
    dataToSend.AppendLine("--" + Boundary + "--");
    dataToSend.AppendLine("");
     
    byte[] bytes = Encoding.ASCII.GetBytes(dataToSend.ToString());
    String httpURL = "https://cpxxxx.pushapi.eval.blackberry.com/mss/PD_pushRequest";
    
    WebRequest tRequest;
    tRequest = WebRequest.Create(httpURL);
    tRequest.Method = "POST";
    tRequest.Credentials = new NetworkCredential(appid, password);
    tRequest.PreAuthenticate = true;
    tRequest.ContentType = "multipart/related; boundary=" + Boundary + "; type=application/xml";
    tRequest.ContentLength = bytes.Length;
    string rawCredentials = string.Format("{0}:{1}", appid, password);
    tRequest.Headers.Add("Authorization",string.Format("Basic {0}",
    Convert.ToBase64String(Encoding.UTF8.GetBytes(rawCredentials))));
    SetBasicAuthHeader(tRequest, appid, password);
    
    Stream dataStream = tRequest.GetRequestStream();
    dataStream.Write(bytes, 0, bytes.Length);
    dataStream.Close();
    
    WebResponse tResponse = tRequest.GetResponse();
    dataStream = tResponse.GetResponseStream();
    StreamReader tReader = new StreamReader(dataStream);
    String sResponseFromServer = tReader.ReadToEnd();
    
    tReader.Close();
    dataStream.Close();
    tResponse.Close();
    }
