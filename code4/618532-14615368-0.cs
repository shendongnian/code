    static void Main(string[] args)
    {
        using (var foobar = new MemoryStream())
        {
            var foo = new Foobar() { FoobarInt = 1 };
            ProtoBuf.Serializer.Serialize(foobar, foo);
            if (foobar.Length == 0)
                throw new Exception("Didn't serialize");
        }
    }
    
    [ProtoContract]
    public class Foobar
    {
        [ProtoMember(1)]
        public int FoobarInt { get; set; }
    }
