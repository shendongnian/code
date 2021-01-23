    public class Foo
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
    
    List<Foo> list = new List<Foo>()
    {
        new Foo() { Type = "a", Value = "aaaa" },
        new Foo() { Type = "a", Value = "bbbb" },
        new Foo() { Type = "b", Value = "cccc" },
        new Foo() { Type = "d", Value = "dddd" },
        new Foo() { Type = "d", Value = "eeee" },
        new Foo() { Type = "d", Value = "ffff" },
        new Foo() { Type = "a", Value = "gggg" },
        new Foo() { Type = "b", Value = "hhhh" },
        new Foo() { Type = "b", Value = "iiii" },
        new Foo() { Type = "b", Value = "jjjj" }
    };
    
    Foo previous = null;
    List<List<Foo>> separateLists = new List<List<Foo>>();
    List<Foo> currentList = null;
    foreach (var foo in list)
    {
        if (null == previous || previous.Type != foo.Type)
        {
            currentList = new List<Foo>();
            separateLists.Add(currentList);
        }
        currentList.Add(foo);
        previous = foo;
    }
