        public void PostMethod()
        {
        ImageConverter converter = new ImageConverter();
        var bytes = (byte[])converter.ConvertTo(bmpScreenshot, typeof(byte[]));
        StringConverter s = new StringConverter();
    
    	string uri = "http://localhost:3844/api/upload";
    
    	byte[] postBytes = bytes;
    	string str = Properties.Settings.Default.token.ToString(); //after login user receives a response token, it is stored in the application settings. All Posts save in db with a this token
    
    	byte[] bA = ASCIIEncoding.ASCII.GetBytes(str);
    
    	MultipartFormDataContent multiPartData = new MultipartFormDataContent();
    
    	ByteArrayContent byteArrayContent = new ByteArrayContent(postBytes);
    	ByteArrayContent bAC = new ByteArrayContent(bA);
    	multiPartData.Add(bAC, "token");
    	multiPartData.Add(byteArrayContent,"picture");
    
    	HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
    	requestMessage.Content = multiPartData;
    
    	HttpClient httpClient = new HttpClient();
    	Task<HttpResponseMessage> httpRequest = httpClient.SendAsync(requestMessage);
    	HttpResponseMessage httpResponse = httpRequest.Result;
    	HttpContent responseContent = httpResponse.Content;
    }
