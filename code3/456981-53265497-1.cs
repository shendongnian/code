    [HttpPost]
    public HttpResponseMessage Post()
        {
               var httpRequest = System.Web.HttpContext.Current.Request;
    
                if (System.Web.HttpContext.Current.Request.Files.Count < 1)
                {
                    //TODO
                }
                else
                {
    
                    try
                    { 
                        foreach (string file in httpRequest.Files)
                        { 
                            var postedFile = httpRequest.Files[file];
                            BinaryReader binReader = new BinaryReader(postedFile.InputStream);
                            byte[] byteArray = binReader.ReadBytes(postedFile.ContentLength);
    
                        }
    
                    }
                    catch (System.Exception e)
                    {
                       //TODO
                    }
                }
     return Request.CreateResponse(HttpStatusCode.Created);
    }
