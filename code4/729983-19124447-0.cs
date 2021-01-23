    IEnumerable errorList = new List<ErrorMessage>();
    
    // ...
    
    var error = new HttpError( "There were errors." ) 
    {
        { "Errors", errorList }
    };
    
    var message = new HttpResponseMessage( HttpStatusCode.BadRequest )
    {
        Content = new ObjectContent<HttpError>( error, GlobalConfiguration.Configuration.Formatters.JsonFormatter )
    };
    
    throw new HttpResponseException( message );
