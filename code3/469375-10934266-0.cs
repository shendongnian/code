    public HttpResponseMessage GetCustomer(int id)
    {
        var customer = db.Customers.Find(id);
        if (customer == null)
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
        
        return Request.CreateResponse(HttpStatusCode.OK, customer);
    }
