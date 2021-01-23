    public XmlDocument Get(int id)
    {
        XmlDocument doc;
        doc = repo.get(id); // simplified
        if(doc != null)
            return doc;
        throw new HttpResponseExeption(
            Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Something went terribly wrong."), Configuration.Formatters.JsonFormatter));
    }
