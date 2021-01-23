    public void PutRate(AppRating model)
    {
       if (model == null)
          throw new HttpResponseException(HttpStatusCode.BadRequest);
       if (ModelState.IsValid)
       {
         // ..
       }      
    }
