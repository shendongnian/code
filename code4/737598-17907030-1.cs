    public class P1
    {
        public string SomeProperty { get; set; }
        public int SomeMethod()
        {
            return 0;
        }
        public void DoWork()
        {
            // Do something
        }
    }
    public class Wrapper
    {
        private P1 Instance { get; set; }
        public string ExposedProperty
        {
            get
            {
                return this.Instance.SomeProperty;
            }
        }
        public Wrapper(P1 instance)
        {
            this.Instance = instance;
        }
        public int ExposedMethod()
        {
            return this.Instance.SomeMethod();
        }
        public void DoWork()
        {
            // Do something else
        }
    }
