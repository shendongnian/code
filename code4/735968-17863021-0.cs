    public class Foo {
        // this is a field:
        private string _name;
        // this is a property:
        public string Name { get; set; }
        // this is also a property:
        public string SomethingElse { get { return _name; } set { _name = value; } }
    }
