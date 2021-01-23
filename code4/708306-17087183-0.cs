    [TestClass]
    public class AutoMapper_Example
    {
        [TestMethod]
        public void AutoMapper_DynamicMap()
        {
            Source source = new Source {Id = 1, Name = "Mr FooBar"};
    
            Target target = Mapper.DynamicMap<Target>(source);
    
            Assert.AreEqual(1, target.Id);
            Assert.AreEqual("Mr FooBar", target.Name);
        }
    
        private class Target
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        private class Source
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
