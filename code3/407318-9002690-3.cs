    public class MyService: IMyService
    {
        private readonly IMyRepository _repository;
        public MyService(IMyRepository repository)
        {
            _repository = repository;
        }
        public SomeModel Get(int id)
        {
            // you could do additional things in the service method
            // like validating the arguments, call data access methods, ...
            return _repository.Get(id);
        }
    }
