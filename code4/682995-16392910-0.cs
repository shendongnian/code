    public HttpResponseMessage LeaveRequest()
    {
        try {
            // do something here
        } 
        catch(Exception ex) {
            // this try-catch block can be temporary 
            // just to catch that 500-error (or any unexpected error)
            // you would not normally have this code-block
            var badResponse = request.CreateResponse(HttpStatusCode.BadRequest);
            badResponse.ReasonPhrase = "include ex.StackTrace here just for debugging";
        }
    }
