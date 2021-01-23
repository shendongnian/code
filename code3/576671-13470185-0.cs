    public class Parent<TChild>
        where TChild : Parent<TChild>
    {
        public string Code { get; protected set; }
    
        public TChild SetCode(string code)
        {
            Code = code;
            return this as TChild; // here we go, we profit from a constraint
        }
    }
    
    public class Child : Parent<Child>
    {
        public string Name { get; protected set; }
    
        public Child SetName(string name)
        {
            Name = name;
            return this // is Child;
        }
    }
    
    [TestClass]
    public class TestFluent
    {
        [TestMethod]
        public void SetProperties()
        {
            var child = new Child();
            child
                .SetCode("myCode") // now still Child is returned
                .SetName("myName");
    
            Assert.IsTrue(child.Code.Equals("myCode"));
            Assert.IsTrue(child.Name.Equals("myName"));
        }
    }
