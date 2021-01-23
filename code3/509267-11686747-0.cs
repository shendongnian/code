    public HttpResponseMessage Post(Person person)
    {
        if (ModelState.IsValid)
        {
            PersonDB.People.Add(person);
            return Request.CreateResponse(HttpStatusCode.Created, person);
        }
        else
        {
            return Request.CreateResponse(HttpStatusCode.Forbidden, person);
        }
    }
