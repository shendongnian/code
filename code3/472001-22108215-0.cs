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
    HTTP/1.1 404 Not Found
    Content-Type: application/json; charset=utf-8
    Date: Thu, 09 Aug 2012 23:27:18 GMT
    Content-Length: 51
    
    {
      "Message": "Product with id = 12 not found"
    }
