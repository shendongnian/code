    public class FooString {
        private readonly string foo;
        private readonly long bar;
        public FooString(string foo) {
            this.foo = foo;
            Match match = Regex.Match(foo, @"\d+$");
            this.bar = Int64.Parse(match);
        }
        public string Foo { get { return this.foo; } }
        public long Bar { get { return this.bar; } }
    }
