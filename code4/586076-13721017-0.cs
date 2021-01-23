    Dictionary<string, object> values = new Dictionary<string, object>()
    {
        {"Name","Joe"},{"Id",123}
    };
    var test = GetObject<TestClass>(values);
---
    class TestClass
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
