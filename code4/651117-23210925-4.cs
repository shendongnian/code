    public class PersonController : ApiController
    {
        private readonly IXyzRepository repository;
        public PersonController(IXyzRepository repo)
        {
            repository = repo;
            
        }
    ...
    ...
    ...
