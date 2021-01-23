    public void Test() {
        var data = new[] {
            new TestData { X = 1, Y = 2, Z = 3 }
        ,   new TestData { X = 2, Y = 4, Z = 6 }
        };
        var strColumns = "X,Z".Split(',');
        foreach (var item in data.Select(a => Projection(a, strColumns))) {
            Console.WriteLine("{0} {1}", item.X, item.Z);
        }
    }
    private static dynamic Projection(object a, IEnumerable<string> props) {
        if (a == null) {
            return null;
        }
        IDictionary<string,object> res = new ExpandoObject();
        var type = a.GetType();
        foreach (var pair in props.Select(n => new {
            Name = n
        ,   Property = type.GetProperty(n)})) {
            res[pair.Name] = pair.Property.GetValue(a, new object[0]);
        }
        return res;
    }
    class TestData {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
