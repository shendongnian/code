    [HttpPost()]
    public HttpResponseMessage Post(YourObjectType value)
    {
        try
        {
    
            var result      = this.Repository.Add(value);
    
            var response = this.Request.CreateResponse<YourObjectType>(HttpStatusCode.Created, result);
    
            if (result != null)
            {
                var uriString               = this.Url.Route(null, new { id = result.Id });
                response.Headers.Location   = new Uri(this.Request.RequestUri, new Uri(uriString, UriKind.Relative));
            }
    
            return response;
        }
        catch (ArgumentNullException argumentNullException)
        {
            throw new HttpResponseException(
                new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase    = argumentNullException.Message.Replace(Environment.NewLine, String.Empty)
                }
            );
        }
    }
