    public class OptionalParamsController : ApiController
    {
        // GET /api/optionalparams?id=5&optionalDateTime=2012-05-31
        public string Get(int id, DateTime? optionalDateTime)
        {
            return optionalDateTime.HasValue ? optionalDateTime.Value.ToLongDateString() : "No dateTime provided";
        }
    }
