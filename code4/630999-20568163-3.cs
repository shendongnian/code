    public static void Register(HttpConfiguration config)
    {
        config.Formatters.Clear();            
        config.Formatters.Add(new JsonMediaTypeFormatter());
        config.MapHttpAttributeRoutes();
    }
    public class YourController : ApiController
    {        
        [HttpGet, Route("getstuff/{stuffId}")]
        public dynamic Get(string stuffId)
        {
            var stuff = Model.Stuff.Get(stuffId);
            return new {
                success= stuff != null,
                stuffId = stuff.Id,
                name = stuff.Name
            };
        }
    }
