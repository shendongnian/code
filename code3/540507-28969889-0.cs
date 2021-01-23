    public ProviderCollection GetProviders(string providerName)
    {
       try
       {
          return _providerPresenter.GetProviders(providerName);
       }
       catch (BadInputValidationException badInputValidationException)
       {
         throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest,
                                              badInputValidationException.Result));
       }
    }
