    void Upload(){
        Web client = new WebClient();
        client.Credentials = new NetworkCredential(username, password);
        client.BaseAddress = "ftp://ftpsample.net/";
    
        client.UploadFile("sample.txt", "sample.txt"); //since the baseaddress
    }
