    var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(fileName));
    fileContent.Headers.ContentDisposition = 
            new ContentDispositionHeaderValue("form-data") //<- 'form-data' instead of 'attachment'
	{
	    Name = "attachment", // <- included line...
	    FileName = "Foo.txt",
    };
    multipartFormDataContent.Add(fileContent);
