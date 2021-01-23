    using ProtoBuf.Meta;
    using System.Collections.Generic;
    using System.IO;
    
    public class MyOtherObject { }
    public class MyObject
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public IList<MyOtherObject> Items { get; set; }
    }
    static class Program
    {
        static readonly RuntimeTypeModel fatModel, liteModel;
        static Program()
        {
            // configure models
            fatModel = TypeModel.Create();
            fatModel.Add(typeof(MyOtherObject), false);
            fatModel.Add(typeof(MyObject), false).Add("Name", "Value", "Items");
            liteModel = TypeModel.Create();
            liteModel.Add(typeof(MyOtherObject), false);
            liteModel.Add(typeof(MyObject), false).Add("Name", "Value");
        }
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
                fatModel.Serialize(file, obj);
            }
            MyObject lite;
            using (var file = File.OpenRead("foo.bin"))
            {
                lite = (MyObject)liteModel.Deserialize(
                    file, null, typeof(MyObject));
            }
        }
    }
