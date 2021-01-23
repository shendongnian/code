    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AreObjectReferencesSameAfterDeserialization()
        {
            A a = new A();
            B b = new B();
            b.A = a;
            b.Items.Add( 1, a );
            Assert.AreSame( a, b.A );
            Assert.AreSame( b.A, b.Items[ 1 ] );
            B deserializedB;
            var model = TypeModel.Create();
            using( var stream = new MemoryStream() )
            {
                model.Serialize( stream, b );
                stream.Seek( 0, SeekOrigin.Begin );
                deserializedB = (B) model.Deserialize( stream, null, typeof(B) );
            }
            Assert.AreSame( deserializedB.A, deserializedB.Items[ 1 ] );
        }
    }
    [ProtoContract]
    public class A
    {
    }
    [ProtoContract]
    public class B
    {
        [ProtoMember( 1, AsReference = true )]
        public A A { get; set; }
        [ProtoMember( 2, AsReference = true )]
        public Dictionary<int, A> Items { get; set; }
        public B()
        {
            Items = new Dictionary<int, A>();
        }
    }
