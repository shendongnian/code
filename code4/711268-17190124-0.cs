    using System;
    using Newtonsoft.Json;
    namespace So17171737_ArrayOrString
    {
        class StringOrArrayConverter : JsonConverter
        {
            public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType) {
                    case JsonToken.String:
                    case JsonToken.Null:
                        return reader.Value;
                    case JsonToken.StartArray:
                        reader.Read();
                        if (reader.TokenType != JsonToken.EndArray)
                            throw new JsonReaderException("Empty array expected.");
                        return "";
                }
                throw new JsonReaderException("Expected string or null or empty array.");
            }
            public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
            public override bool CanConvert (Type objectType)
            {
                return objectType == typeof(string);
            }
        }
        class Program
        {
            private const string json = @"
    {
        s1: 'str1',
        s2: [],
        s3: null
    }
    ";
            static void Main ()
            {
                Foo foo = JsonConvert.DeserializeObject<Foo>(json, new JsonSerializerSettings {
                    Converters = { new StringOrArrayConverter() }
                });
                Console.WriteLine(JsonConvert.SerializeObject(foo, Formatting.Indented));
                Console.ReadKey();
            }
            class Foo
            {
                public string s1, s2, s3;
            }
        }
    }
