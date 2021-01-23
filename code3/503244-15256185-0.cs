    [HttpGet]
    public HttpResponseMessage MyActionMethod() {
        var result = // response data
    	var response = Request.CreateResponse<MyType>(HttpStatusCode.OK, result);
        response.Headers.Add("Last Modified", result.Modified.ToString("R"));
    	response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue(CreateEtag(result));
        return response;
    }
