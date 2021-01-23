    public class ServcomController : ApiController
    {
        [HttpPut, HttpPost]
        public HttpResponseMessage Vis(HttpRequestMessage request)
        {
            var idTerm = request.GetRouteData().Values["idTerm"];
            var body = request.Content.ReadAsStringAsync().Result;
            return "PUT/POST Vis for: " + idTerm;
        }
    }
