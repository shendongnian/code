    public HttpResponseMessage Post(Person person)
    {
        if (ModelState.IsValid)
        {
            PersonDB.Add(person);
            return Request.CreateResponse(HttpStatusCode.Created, person);
        }
        else
        {
            // the code below should probably be refactored into a GetModelErrors
            // method on your BaseApiController or something like that
            var errors = new List<string>();
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden, errors);
        }
    }
