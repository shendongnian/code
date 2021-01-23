    [HttpPut]
    public HttpResponseMessage Update(MyModel model)
    {
        if(notfound)
        {
          return this.Request.CreateResponse(HttpStatusCode.NotFound);
        }
        
        //make update
        return this.Request.CreateResponse<MyModel>(HttpStatusCode.OK, Model);;
    }
