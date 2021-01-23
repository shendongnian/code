    public HttpResponseMessage GetProduct(int id)
    {
        Product item = repository.Get(id);
        if (item == null)
        {
            var message = string.Format("Product with id = {0} not found", id);
            HttpError err = new HttpError(message);
            return Request.CreateResponse(HttpStatusCode.NotFound, err);
        }
        else
        {
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }
    }
