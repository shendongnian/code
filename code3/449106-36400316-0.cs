    [Route("api/MethodReturingDynamicData")]
    [HttpPost]
    public HttpResponseMessage MethodReturingDynamicData(RequestDTO request)
    {
        HttpResponseMessage response;
        try
        {
            GenericResponse result = new GenericResponse();
    		dynamic data = new ExpandoObject();
            data.Name = "Subodh";
                    
            result.Data = data;// OR assign any dynamic data here;// 
    
            response = Request.CreateResponse<dynamic>(HttpStatusCode.OK, result);
        }
        catch (Exception ex)
        {
            ApplicationLogger.LogCompleteException(ex, "GetAllListMetadataForApp", "Post");
            HttpError myCustomError = new HttpError(ex.Message) { { "IsSuccess", false } };
            return Request.CreateErrorResponse(HttpStatusCode.OK, myCustomError);
        }
        return response;
    }
