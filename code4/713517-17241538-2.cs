    public class SomeClass
    {
        private readonly IMyConfigRepository _repo;
        public MyClass(IMyConfigRepository repo)
        {
            _repo = repo;
        }
        
        public void DoSomethingThatNeedsTheConfigSettings()
        {
            var settings = _repo.Load();
            //...
        }
    }
