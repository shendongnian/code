    public class Test1
    {
        public List<Test1Child> Children { get; set; }
    }
    public class Test2
    {
        public List<Test2Child> Children { get; set; }
    }
    public class Test1Child
    {
        public int ChildId { get; set; }
        public int Value { get; set; }
    }
    public class Test2Child
    {
        public int ChildId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Test2Child() 
        { }
        
        public Test2Child(int childId)
        {
            // of course you will need to load this from your data source, but for testing.  :)
            if (childId == 1)
            {
                ChildId = 1;
                Name = "fred";
                Value = 456;
            }
        }
    }
    Mapper.CreateMap<Test1, Test2>();
    Mapper.CreateMap<Test1Child, Test2Child>()
        .ConstructUsing(t => t.ChildId > 0 ? new Child(t.ChildId) : new Child())
        .ForMember(m => m.Name, o => o.Ignore());
    Mapper.AssertConfigurationIsValid();
    var c = new Test1 { Children = new List<Test1Child> { new Test1Child { ChildId = 1, Value = 123 } } };
    var d = new Test2 { Children = new List<Test2Child> { new Test2Child { ChildId = 1, Name = "fred", Value = 456 } } };
    Mapper.Map(c, d);
    Assert.AreEqual(d.Children[0].Value, 123);
    Assert.AreEqual(d.Children[0].Name, "fred");
