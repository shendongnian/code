    public class SomeWrapper
    {
        private readonly List<MyClass> items = new List<MyClass>();
        [ProtoSharp.Core.Tag(1)]
        public List<MyClass> Items { get { return items; } }
    }
    ...
    var tmp = new SomeWrapper();
    tmp.Items.AddRange(_forSerialize);
    using (FileStream fs = File.Create("test.ProtoSharp"))
        ProtoSharp.Core.Serializer.Serialize(fs, tmp);
    using (FileStream fs = File.OpenRead("test.ProtoSharp"))
        _forSerialize = ProtoSharp.Core.Serializer.Deserialize<SomeWrapper>(fs).Items;
    if (_forSerialize.Count == 4)
        Console.WriteLine("ProtoSharp serializer work");
