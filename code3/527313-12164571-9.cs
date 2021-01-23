    public class test : basetest
    {
        private object test1;
        private object test2;
        public test()
        {
            //prepend everything first
            this.test1 = new object();
            //call base
            base(); //not legal but just an example
            //everything else that was already here
            this.test2 = new object();
        }
    }
    public class basetest
    {
        private object basetest1;
        private object basetest2;
        public basetest()
        {
            //prepend initializers
            this.basetest1 = new object();
            //if there were more base classes, the constructors would be called here
            //do everything else that was already here
            this.basetest2 = new object();
        }
    }
