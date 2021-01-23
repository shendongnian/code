        public class ValuesController : ApiController
        {
            private readonly IRepository _repo;
            public ValuesController(IRepository repo)
            {
                _repo = repo;
            }
            public string Get()
            {
                return _repo.GetData();
            }
        }
