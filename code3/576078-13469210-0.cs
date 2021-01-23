    public class HttpNotFoundException : HttpResponseException
    {
        public HttpNotFoundException(string reason)
            : base(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound, ReasonPhrase = reason })
        { }
    }
    public class HttpInternalServerError : HttpResponseException
    {
        public HttpInternalServerError(string reason)
            : base(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError, ReasonPhrase = reason })
        { }
    }
    public class ResourceApiController : ApiController
    {
        IRepository Repository { get; set; }
        /// <summary>
        /// Delete a resource.
        /// </summary>
        /// <param name="id">Resource ID.</param>
        /// <exception cref="HttpNotFoundException">Resource not found.</exception>
        /// <exception cref="HttpInternalServerError">An internal error was detected, for instance in database service.</exception>
        public void DeleteResourceById(string id)
        {
            try
            {
                Repository.Delete(id);
            }
            catch (WebResourceNotFoundError)
            {
                throw new HttpNotFoundException(string.Format("Build '{0}' not found", id));
            }
            catch (DatabaseServiceException)
            {
                throw new HttpInternalServerError("Database service operation failed");
            }
        }
    }
