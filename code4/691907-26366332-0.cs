    public class Test
    {
        private Test()
        {
            Debug.WriteLine("private constructor has been called in class Test");
        }
        public virtual string Run()
        {
            return "Test.Run";
        }
        public static Test GetTestRequest()
        {
            return new Test(); 
        }
        public static DerivedTest GetDerivedTestRequest()
        {
            return new DerivedTest();
        }
        public class DerivedTest:Test
        {
            public DerivedTest()
            {
                Debug.WriteLine("public constructor has been called in derived class DerivedTest.");
            }
            public override string Run()
            {
                return "DerivedTest.Run";
            }
        }
    }
