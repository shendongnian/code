    public class WebController : ApiController
    {
        public void Get(string telephone, 
                        string postcode, 
                        [FromUri]List<Client> clients)
        {
        }
    }
