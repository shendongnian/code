    using System;
    using Newtonsoft.Json;
    namespace So16972364JsonDeserializeConverter
    {
        class BoolConverter : JsonConverter
        {
            public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
            public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType) {
                    case JsonToken.String:
                        if ((string)reader.Value == "")
                            return false;
                        break;
                    case JsonToken.Boolean:
                        return reader.Value;
                }
                throw new JsonReaderException("Expected boolean or empty string.");
            }
            public override bool CanConvert (Type objectType)
            {
                return objectType == typeof(bool);
            }
        }
        class Program
        {
            const string json = @"
    {
        b1: true,
        b2: false,
        b3: ''
    }
    ";
            static void Main ()
            {
                Foo foo = JsonConvert.DeserializeObject<Foo>(json, new JsonSerializerSettings {
                    Converters = { new BoolConverter() }
                });
                Console.WriteLine(JsonConvert.SerializeObject(foo, Formatting.Indented));
                Console.ReadKey();
            }
        }
        class Foo
        {
            public bool b1, b2, b3;
        }
    }
