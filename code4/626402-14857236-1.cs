     public HttpResponseMessage GetZipCode(int id)
    {
        ZipCode zipcode = db.ZipCodes.Find(id);
        if (zipcode == null)
        {
            return Request.CreateResponse(HttpStatusCode.NotFound)
        }
        return Request.CreateResponse(HttpStatusCode.OK,zipcode);
    }
