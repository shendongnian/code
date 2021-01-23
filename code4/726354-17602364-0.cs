        public class Foo
        {
            public object Value { get; set; }
        }
        Foo original = new Foo
            {
                Value = 1.23m
            };
        string json = JsonConvert.SerializeObject(original);
        var settings = new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Decimal //hint
            };
        Foo actual = JsonConvert.DeserializeObject<Foo>(json, settings);
       
        // actual.Value.GetType() == 'Decimal'
