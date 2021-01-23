    public class MyClass
    {
        private IRepository repo;
        public MyClass(IRepository repo)
        {
            this.repo = repo;
        }
        public void Do()
        {
            ....
        }
    }
