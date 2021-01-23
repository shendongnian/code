    [HttpGet]
    public User GetUser(int id)
    {
        if (id > 0 && validIds.Contains(id))
        {
            //Go do something fun...
        }
        else
            throw new HttpResponseException(
                new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        ReasonPhrase = String.Format("A valid id is required. {0} is most definitely not a valid id.", id);
                    }
          
      );
}
