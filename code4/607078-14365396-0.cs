    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();
            //dict.Add("SomeKey", "SomeProperty1");
            dict.Add("SomeKey", "SomeProperty2");
            var mySerializer = new MyConverter();
            var serialized = mySerializer.Serialize(dict, new SomeObjectModel() { SomeProperty1 = 1, SomeProperty2 = 2 }, new MySerializer());
        }
        class MySerializer : JavaScriptSerializer
        { }
        class MyConverter : JavaScriptConverter
        {
            Dictionary<string, string> _theJsonDictionary;
            public IDictionary<string, object> Serialize(Dictionary<string, string> TheJsonDictionary, object obj, JavaScriptSerializer serializer)
            {
                _theJsonDictionary = TheJsonDictionary;
                return Serialize(obj, serializer);
            }
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                SomeObjectModel TheObject = obj as SomeObjectModel;
                Dictionary<string, object> OutputJson = new Dictionary<string, object>();
                OutputJson.Add("SomeKey", TheObject.GetType().GetProperty(_theJsonDictionary["SomeKey"]).GetValue(TheObject));
                return OutputJson;
            }
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                return new object();
            }
            public override IEnumerable<Type> SupportedTypes
            {
                get { return new[] { typeof(object) }.AsEnumerable(); }
            }
        }
        class SomeObjectModel
        {
            public int SomeProperty1 { get; set; }
            public int SomeProperty2 { get; set; }
        }
    }
