    WebClient webClient = new WebClient();
    
    var data = webClient.DownloadString("<your endpoint>");  //You can do this async too
    
    var serializer = new DataContractSerializer(typeof(UserData));
    
    Byte[] bytes = Encoding.Unicode.GetBytes(data);
    
    UserData userData;
    using (MemoryStream stream = new MemoryStream(bytes))
    {
        userData = serializer.ReadObject(stream) as UserData;
    }
