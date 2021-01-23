    public class ServcomController : ApiController
    {
        [HttpPut, HttpPost]
        public string Vis(long id) // << "idTerm" to "id"
        {
            return "PUT/POST Vis for: " + idTerm;
        }
    }
