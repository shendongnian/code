    while(response==null)
    {
    httpWebRequest = (HttpWebRequest)WebRequest.Create(sURL + param);
    httpWebRequest.Method = WebRequestMethods.Http.Post;
    httpWebRequest.Accept = "application/xml";
    httpWebRequest.ContentLength = 0;
               
    try
    {
    response = (HttpWebResponse)httpWebRequest.GetResponse();
    if (response.StatusCode == HttpStatusCode.OK && response != null)
    {
     streamReader = new StreamReader(response.GetResponseStream());
     doc = XDocument.Load(streamReader);
     break;
    }
    }
    catch (WebException exx)
    {
    Console.WriteLine("Trying to reconnect with Web Server");
    Thread.Sleep(2000);
    }
    }
                           
           
            
