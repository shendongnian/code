    GlobalConfiguration.Configuration.Filters.Add(
        new UnhandledExceptionFilterAttribute()
        .Register<KeyNotFoundException>(HttpStatusCode.NotFound)
                        
        .Register<SecurityException>(HttpStatusCode.Forbidden)
    
        .Register<SqlException>(
            (exception, request) =>
            {
                var sqlException = exception as SqlException;
    
                if (sqlException.Number > 50000)
                {
                    var response            = request.CreateResponse(HttpStatusCode.BadRequest);
                    response.ReasonPhrase   = sqlException.Message.Replace(Environment.NewLine, String.Empty);
    
                    return response;
                }
                else
                {
                    return request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
        )
    );
