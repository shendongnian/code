     String uriString = Console.ReadLine();
    
    // Create a new WebClient instance.
    WebClient myWebClient = new WebClient();
    myWebClient.Credentials=new NetworkCredential(username, password);
    Console.WriteLine("\nPlease enter the fully qualified path of the file to be uploaded to the URI");
    string fileName = Console.ReadLine();
    Console.WriteLine("Uploading {0} to {1} ...",fileName,uriString);
    
    // Upload the file to the URI.
    // The 'UploadFile(uriString,fileName)' method implicitly uses HTTP POST method.
    byte[] responseArray = myWebClient.UploadFile(uriString,fileName);
