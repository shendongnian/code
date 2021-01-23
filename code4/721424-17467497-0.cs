    public class TestAttribute : Attribute
    { public string Bar { get; set; } }
    
    public class TestClass
    {
        [Test]
        public string Foo()
        { return string.Empty; }
    }
