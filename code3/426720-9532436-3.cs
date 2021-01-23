    public class MyServices : IMyServices
    {
        private readonly IMyRepository _myRepository;
        public MyServices(IMyRepository myRepository)
        {
            _myRepository = myRepository;
        }
        public void Example()
        {
            _myRepository.PleaseDoSomething();
        }
    }
