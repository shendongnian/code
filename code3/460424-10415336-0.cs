    public class ClassOne
    {
        public static int MyStaticInteger { get { return 1; } }
        public int x { get; set; }
        public int y { get; set; }
    }
    
    public class ClassTwo
    {
        public const string hehe = "xd";
    
        public void doSomething(ClassOne myOtherClass)
        {
            if (myOtherClass.x != 5)
            {
    
            }
            if (ClassOne.MyStaticInteger != 5)
            {
            }
        }
    }
