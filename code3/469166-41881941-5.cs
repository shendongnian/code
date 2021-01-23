    [HttpPost]
    public IHttpActionResult Post(Model model)
    {
        return model.Id == 1 ?
                    Ok() :
                    CustomResult(HttpStatusCode.NotAcceptable, new { 
                        data = model, 
                        error = "The ID needs to be 1." 
                    });
    }
