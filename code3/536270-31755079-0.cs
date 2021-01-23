    [TestClass]
    public class UnitTestJammieJawns
    {
        [TestMethod]
        public void ProtobufAbstract_TestMethod()
        {
            var sub = new Sub() { AbstractInt = 234 , OtherInt32 = 987, SomeString = "qwer" };
            byte[] buffer = null;
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, sub);  // works - hooray!
                buffer = ms.ToArray();  // we've got binary content, people!
            }
            Sub obj = null;
            using (var ms = new MemoryStream())  // woops... you forgot the provide the serialized object - should be: new MemoryStream(buffer) 
            {
                obj = ProtoBuf.Serializer.Deserialize<Sub>(ms);  // <- throws exception (this is good) with misleading message (this is not so good)
            }
        }
    }
    [ProtoContract]
    [ProtoInclude(1, typeof(Sub))]
    public abstract class Super
    {
        public abstract int AbstractInt { get; set; }
        [ProtoMember(1)]
        public string SomeString { get; set; }
    }
    [ProtoContract]
    public class Sub : Super
    {
        [ProtoMember(2)]
        private int asdf;
        public override int AbstractInt
        {
            get
            {
                return asdf;
            }
            set
            {
                asdf = value;
            }
        }
        [ProtoMember(3)]
        public int OtherInt32 { get; set; }
    }
