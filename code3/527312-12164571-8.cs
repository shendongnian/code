    public class test : basetest
    {
        private object test1 = new object();
        private object test2;
        public test() : base()
        {
            this.test2 = new object();
        }
    }
    public class basetest
    {
        private object basetest1 = new object();
        private object basetest2;
        public basetest()
        {
            this.basetest2 = new object();
        }
    }
