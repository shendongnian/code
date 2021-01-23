    public class TestInherit : Child
    {
        public TestInherit()
            : base(Environment.MachineName=="MyPC" ? "here" : "there")
        {
        }
    }
    public class Child
    {
        public Child(string name) { }
    }
