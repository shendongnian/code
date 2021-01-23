	public class TryController : ApiController
	{
        public IHttpActionResult GetUser(int userId, DateTime lastModifiedAtClient)
        {
            var user = new DataEntities().Users.First(p => p.Id == userId);
            if (user.LastModified <= lastModifiedAtClient)
            {
                return StatusCode(HttpStatusCode.NotModified);
                // If you would like to return a Http Status code with any object instead:
                // return Content(HttpStatusCode.InternalServerError, "My Message");
            }
            return Ok(user);
        }
	}
