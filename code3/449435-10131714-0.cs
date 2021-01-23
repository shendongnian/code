    public class Foo {
        public String FooField { get; set; }
        public String NotSerializedFooString { get; set; }
    }
    public class FooConverter : JavaScriptConverter {
        public override Object Deserialize(IDictionary<String, Object> dictionary, Type type, JavaScriptSerializer serializer) {
            throw new NotImplementedException();
        }
        public override IDictionary<String, Object> Serialize(Object obj, JavaScriptSerializer serializer) {
            // Here I'll get instances of Foo only.
            var data = obj as Foo;
            // Prepare a dictionary
            var dic = new Dictionary<String, Object>();
            // Include only those values that should be there
            dic["FooField"] = data.FooField;
            // return the dictionary
            return dic;
        }
        public override IEnumerable<Type> SupportedTypes {
            get {
                // I return the array with only one element.
                // This means that this converter will be used with instances of
                // only this type.
                return new[] { typeof(Foo) };
            }
        }
    }
