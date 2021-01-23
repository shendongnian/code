    [System.Web.Http.AcceptVerbs("Post")]
    public HttpResponseMessage DeleteComplexObject(Models.ComplexObject deleteme)
    {
        this.ComplexObjectService.Delete(deleteme);
        var response = Request.CreateResponse(HttpStatusCode.Accepted);
    
        return response;
    }
