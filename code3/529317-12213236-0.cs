    [HttpPut]
    public MyModel Update(MyModel model)
    {
        return base.Request.CreateResponse<MyModel>(HttpStatusCode.OK, UpdateModel(model));;
    }
    [NonAction]
    internal MyModel UpdateModel(MyModel model)
    {
        //make update
        return model;
    }
