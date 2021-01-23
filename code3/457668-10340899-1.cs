	HttpClient c = new HttpClient();
	var fileContent = new ByteArrayContent(new byte[100]);
	fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
			                                    {
			                                        FileName = "myFilename.txt"
			                                    };
	var formData = new FormUrlEncodedContent(new[]
			                                    {
			                                        new KeyValuePair<string, string>("name", "ali"),
			                                        new KeyValuePair<string, string>("title", "ostad")
			                                    });
			
			
	MultipartContent content = new MultipartContent();
	content.Add(formData);
	content.Add(fileContent);
	c.PostAsync(myUrl, content);
