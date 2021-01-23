    public class ServcomController : ApiController
    {
        [HttpPut, HttpPost]
        public string Vis(long idTerm)
        {
            return "PUT/POST Vis for: " + idTerm;
        }
    }
