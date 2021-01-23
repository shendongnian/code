    class Foo {
        public Bar myBar { get; set; }
    }
    class Bar {
        public string name { get; set; }
    }
    static void Main() {
        var expression = CreateExpression(typeof(Foo), "myBar.name");
        // x => x.myBar.name
    }
?
