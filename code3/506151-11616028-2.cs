      [TestFixture]
        public class InheritanceTest
        {
            [DataContract]
            public class Base
            {
                [DataMember(Order = 1)]
                public int IntField { get; private set; }
        
                public Base(int intField)
                {
                    IntField = intField;
                }
                protected Base(){}
            }
        
            [DataContract]
            public class Derived : Base
            {
                [DataMember(Order = 3)]
                public string StringField { get; private set; }
        
                public Derived(int intField, string stringField) : base(intField)
                {
                    StringField = stringField;
                }
                private Derived(){}
            }
        
            [Test]
            public void TestInheritance()
            {
                RuntimeTypeModel.Default.Add(typeof(Base), true).AddSubType(2, typeof(Derived));
        
                 using (var stream = new MemoryStream())
                    {
                        var message = new Derived(1, "Some text that is not important");
        
                        Serializer.Serialize(stream, message);
                        stream.Position = 0;
        
                        var retrieved = Serializer.Deserialize<Derived>(stream);            
        
                        Assert.AreEqual(message.IntField, retrieved.IntField);
                        Assert.AreEqual(message.StringField, retrieved.StringField);
                }
            }
        
        }
