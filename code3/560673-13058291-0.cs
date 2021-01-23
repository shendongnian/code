    class MyController
    {
        readonly Func<string,ICarRepository> _createRepository;
        public MyController(Func<string,ICarRepository> createRepository)
        {
            _createRepository = createRepository;
        }
