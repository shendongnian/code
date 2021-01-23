        public static void Main(string[] args)
        {
            var foo = new Foo { Bar = new Bar { Value = "Testing" } };
            foo.Cmp(f => f.Bar.Value == "Testing"); // True
        }
