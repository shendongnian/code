    [HttpGet]
    [Route("file/{id}/")]
    public IHttpActionResult GetFileForCustomer(int id)
    {
        if (id == 0)
          return BadRequest();
    
        var file = GetFile(id);
    
        IHttpActionResult response;
        HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.OK);
        responseMsg.Content = new ByteArrayContent(file.SomeData);
        responseMsg.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        responseMsg.Content.Headers.ContentDisposition.FileName = file.FileName;
        responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        response = ResponseMessage(responseMsg);
        return response;
    }
