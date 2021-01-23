	var contents = "some long HTML that I wanted to upload";
	var fileName = "Some fancy file name.html";
	
	using (var client = new HttpClient())
	{
		var uri = new Uri(URL);
		
		client.BaseAddress = new Uri(URL);
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		
		client.DefaultRequestHeaders.Authorization = authorization;
		client.DefaultRequestHeaders.Add("X-Atlassian-Token", "nocheck");
		
		var uriPath = String.Format(AttachmentPath, pageId);
		
		var content = new MultipartFormDataContent();
		var fileContent = new StringContent(contents);
		// also tested to work: 
		// var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes(contents));
        content.Add(fileContent, "file", fileName);
		
		var response = await client.PostAsync(uriPath, content);
		if (response.IsSuccessStatusCode)
		{
			return TaskResult.Success(null, response.ReasonPhrase);
		}
		else
		{
			return TaskResult.Failure("Service responded with Status Code: " + response.StatusCode + Environment.NewLine + "Reason Phrase: " + response.ReasonPhrase);
		}
	}
