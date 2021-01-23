    public IHttpActionResult Save(MyEntity entity)
    {
      ....
    
        return ResponseMessage(
            Request.CreateResponse(
                HttpStatusCode.BadRequest, 
                validationErrors));
    }
