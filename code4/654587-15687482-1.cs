    public HttpResponseMessage GetDocumentContent(int id)
    {
    	Document document = Repository.StorageFor<Client>().GetDocument(id);
    	HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
        response.Headers.CacheControl = new CacheControlHeaderValue(); // REQUIRED    	response.Content = new ByteArrayContent(document.GetBuffer());
    	response.Content.Headers.ContentLength = document.GetBuffer().Length;
    	response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    	{
    		FileName = "document.docx"
    	};
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        return response;
    }
