    [HttpPost]
    public HttpResponseMessage Post()
    {
         
    	    HttpRequestMessage request = this.Request;
    
                if (!request.Content.IsMimeMultipartContent() || System.Web.HttpContext.Current.Request.Files.Count < 1)
                {
                   //TODO
                }
                else
                {
                    string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
                    var provider = new MultipartFormDataStreamProvider(root);
    
                    try
                    {
                        Request.Content.ReadAsMultipartAsync(provider);
                        List<String> payload = new List<string>();
    
                        foreach (var file in provider.FileData)
                        {                       
                            var path = file.LocalFileName;
                            byte[] byteArray = File.ReadAllBytes(path);
                       
                        }
    
                    }
                    catch (System.Exception e)
                    {
                        //TODO
                    }
                }
    	 
    
        return Request.CreateResponse(HttpStatusCode.Created);
    }
