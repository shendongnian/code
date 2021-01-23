    using ProtoBuf;
    using System.Collections.Generic;
    using System.IO;
    
    [ProtoContract]
    public class MyOtherObject { }
    [ProtoContract]
    public class MyObject
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public int Value { get; set; }
        [ProtoMember(3)]
        public IList<MyOtherObject> Items { get; set; }
    }
    
    [ProtoContract]
    public class MyObjectLite
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public int Value { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            var obj = new MyObject
            {
                Name = "abc",
                Value = 123,
                Items = new List<MyOtherObject>
                {
                    new MyOtherObject(),
                    new MyOtherObject(),
                    new MyOtherObject(),
                    new MyOtherObject(),
                }
            };
            using (var file = File.Create("foo.bin"))
            {
                Serializer.Serialize(file, obj);
            }
            MyObjectLite lite;
            using (var file = File.OpenRead("foo.bin"))
            {
                lite= Serializer.Deserialize<MyObjectLite>(file);
            }
        }
    }
