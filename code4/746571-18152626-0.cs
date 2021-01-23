    public async Task<string> submitFeedback(String token, String subject, String body, byte[] photo, byte[] video) {
    	var client = new HttpClient();
    	var content = new MultipartFormDataContent(); 
    
    	// Some APIs do not support quotes in boundary field
    	foreach (var param in content.Headers.ContentType.Parameters.Where(param => param.Name.Equals("boundary")))
    		param.Value = param.Value.Replace("\"", String.Empty);
    
    	var tok = new StringContent(token);
    	content.Add(tok, "\"token\"");
    	var sub = new StringContent(subject);
    	content.Add(tok, "\"subject\"");
    
    	// Add the Photo 
    	var photoContent = new StreamContent(new MemoryStream(photo));
    	photoContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
    	{
    		Name = "\"photo\"",
    		FileName = "\"photoname.jpg\""
    	};
    	photoContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
    	content.Add(photoContent);
    	
    	// Add the video
    	var videoContent = new StreamContent(new MemoryStream(video));
    	videoContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
    	{
    		Name = "\"video\"",
    		FileName = "\"videoname.jpg\""
    	};
    	videoContent.Headers.ContentType = MediaTypeHeaderValue.Parse("video/mp4");
    	content.Add(videoContent);
    
    	HttpResponseMessage resp;
    
    	try {	        
    		resp = await client.PostAsync("SERVER_URL_GOES_HERE", content);
    	}
    	catch (Exception e)
    	{
    		return "EXCEPTION ERROR";
    	}
    
    	if (resp.StatusCode != HttpStatusCode.OK)
    	{
    		return resp.StatusCode.ToString();
    	}
    
    	var reponse = await resp.Content.ReadAsStringAsync();
    
    	return reponse;
    }
