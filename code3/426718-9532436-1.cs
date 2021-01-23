    public class MyServices : IMyServices
    {
        private readonly IMyRepository _myRepository;
        public MyServices()
        {
            _myRepository = new myRepository();
        }
        public void Example()
        {
            _myRepository.PleaseDoSomething();
        }
    }
