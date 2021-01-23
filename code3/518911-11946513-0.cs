        public class ValuesController : ApiController
        {
            public string Get(Guid caller, Guid id, string ip, string signature, Guid eventID)
            {
                return signature;
            }
        }
