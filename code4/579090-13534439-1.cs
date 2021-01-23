    public void RetrieveNotams()
    {
        string myURL = "https://www.example.com/SecureSite";
        // Open the certificate store for the current user in readonly mode,
        // and find the certificate I need to user
        X509Store xstore = new X509Store(StoreLocation.CurrentUser);
        xstore.Open(OpenFlags.ReadOnly);
        X509Certificate cert=null; 
        foreach (X509Certificate c in xstore.Certificates)
            if(c.Subject.StartsWith("CN=aidapuser"))
                cert=c;          
        
        HttpWebRequest req;
        req = (HttpWebRequest)WebRequest.Create(myURL);
        // add the certificate to the request
        req.ClientCertificates.Add(cert);
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        string postData = "uid=UUUUUUU&password=PPPPPP&active=Y&type=I";
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        req.ContentLength = byteArray.Length;
        // add the parameters to POST to the URL
        using (Stream dataStream = req.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }
        
        // grab the response and show the first 10 lines
        using (StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream()))
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(sr.ReadLine());
        }
                    
    }
