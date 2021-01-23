    private POP3 pop3 = new POP3();
    pop3.Connect(pop3Address, port);
    var memoryStream = new MemoryStream();
    pop3.DownloadMessage(position, memoryStream);
    var email = new EmailMessage(memoryStream)
    var streamView = new HTMLStreamView(email, urlPrefix);
    string body = streamView.Body;
    int counter = 0;
    
    foreach (Stream stream in streamView.Streams)
    {
        if (counter != 0)
        {
    	    stream.Position = 0;
    	    byte[] embeddedObjectBytes = new byte[(int)stream.Length];
    	    stream.Read(embeddedObjectBytes, 0, (int)stream.Length);
    
    	    string urlAndCounter = urlPrefix + counter.ToString();
    	    string uniqueUrlAndCounter = GetUniqueUrl(urlAndCounter);
    	    if (body.Contains(urlAndCounter + "\""))
    	    {
    		  body = body.Replace(urlAndCounter + "\"", uniqueUrlAndCounter + "\"");
    	    }
    	    else if (body.Contains(urlAndCounter + " "))
    	    {
    		  body = body.Replace(urlAndCounter + " ", uniqueUrlAndCounter + " ");
    	    }
    	
    	    SaveEmbeddedObject(embeddedObjectBytes,uniqueUrlAndCounter);
        }
    
        counter++;
    }
