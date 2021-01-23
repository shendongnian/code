    public class Test
    {
        public class InnerGroup
        {
            public static void Method1() { }
        }
        public class AnotherInnerGroup
        {
            public static void Method2() { }
        }
        public InnerGroup InnerGroup { get; set; }
        public AnotherInnerGroup AnotherInnerGroup { get; set; }
        public Test()
        {
            InnerGroup = new InnerGroup();
            AnotherInnerGroup= new AnotherInnerGroup();
        }
    }
