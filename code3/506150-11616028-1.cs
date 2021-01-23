      [TestFixture]
    public class InheritanceTest
    {
        public class Base
        {
            public int IntField { get; private set; }
    
            public Base(int intField)
            {
                IntField = intField;
            }
        }
    
        public class Derived : Base
        {
            public string StringField { get; private set; }
    
            public Derived(int intField, string stringField) : base(intField)
            {
                StringField = stringField;
            }
        }
    
        [Test]
        public void TestInheritance()
        {
            var serializer = TypeModel.Create();
            serializer.Add(typeof (Base), true)
                .Add(1, "IntField")
                .UseConstructor = false;
    
            serializer.Add(typeof (Derived), true)
                .Add(1, "StringField")
                .UseConstructor = false;
    
            serializer.CompileInPlace();
    
            using (var stream = new MemoryStream())
            {
                var message = new Derived(1, "Some text that is not important");
    
                serializer.Serialize(stream, message);
                stream.Position = 0;
    
                var retrieved = (Derived) serializer.Deserialize(stream, null, typeof (Derived));
    
                Assert.AreEqual(message.IntField, retrieved.IntField);
                Assert.AreEqual(message.StringField, retrieved.StringField);
            }
        }
    
    }
