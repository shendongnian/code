    [HttpGet]
    [ActionName("all")]
    public HttpResponseMessage GetCategoryList(ODataQueryOptions<Category> options)
    {          
        var categoryList = this.Repository.GetCategories().AsQueryable<Category>();
        categoryList = options.ApplyTo(categoryList) as IQueryable<Category>;
        return Request.CreateResponse(HttpStatusCode.OK, new ResponseMessage<IQueryable<Category>> { success = true, data = categoryList });
    }
