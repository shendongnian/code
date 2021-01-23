    string restURL="www.yoursite.com/yourphpwebservice.php";
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(restURL);
    request.Method = "GET";
    request.Accept = "text/xml";
    request.ContentType = "text/xml";
                    
    response = (HttpWebResponse)request.GetResponse();              
    if (response.StatusCode == HttpStatusCode.OK)
    {
        using (WebResponse response2 = request.GetResponse())
        using (Stream stream = response2.GetResponseStream())
        {                       
            XElement myXel = XElement.Load(stream);
            if (myXel != null)
            {
              //now you can access the XML elements with LINQtoXML
            }
        }
    }
