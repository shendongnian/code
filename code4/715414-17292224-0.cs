    public class Foo
    {
        public string Name { get; set; }
        public Foo()
        {
            ResetName();
        }
        public void ResetName()
        {
            Name = "Some default value";
        }
    }
