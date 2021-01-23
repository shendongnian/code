    namespace Company.Project.SubProject.Area.Test.AndSomeMore
    {
        public class TestClass
        {
            public TestEnum MyEnum { get; set; }
            public TestEnum TestEnum { get; set; }
            public SndTestEnum NewEnum { get; set; }
        }
        public enum TestEnum
        {
            None,
            One,
            Two
        }
        public enum SndTestEnum
        {
            None,
            One,
            Two
        }
    }
    namespace MyCallerNS
    {
        public class MyTestClass : TestClass
        {
            public MyTestClass()
            {
                this.TestEnum = Company.Project.SubProject.Area.Test.AndSomeMore.TestEnum.One;
                this.MyEnum = Company.Project.SubProject.Area.Test.AndSomeMore.TestEnum.Two;
                this.NewEnum = SndTestEnum.None;
            }
        }
    }
