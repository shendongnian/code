       using System;
     using System.Collections.Generic;
     using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    namespace NewtonTest
    {
    internal class NewtonTest
    {
        public class Data
        {
            public IEnumerable<IUnit> Unit { get; set; }
            public override string ToString()
            {
                return string.Format("Data{{Unit=[{0}]}}",
                    string.Join(", ", Unit.Select(c =>
                                    string.Format("{0} - Single Unit: {1}", 
                                        c.Name,
                                        c.isSingleUnit.ToString()))));
            }
        }
        public interface IUnit
        {
            string Name { get; }
            // [JsonConverter(typeof(Converter))]
            bool isSingleUnit { get; }
        }
        public class House : IUnit
        {
            public House(string name, bool isSingle)
            {
                this.Name = name;
                this.isSingleUnit = isSingle;
            }
            public string Name { get; private set; }
            public bool isSingleUnit { get; private set; }
        }
        public class Apartment : IUnit
        {
            public Apartment(string name, bool isSingle)
            {
                this.Name = name;
                this.isSingleUnit = isSingle;
            }
            public string Name { get; private set; }
            public bool isSingleUnit { get; private set; }
        }
        private static bool ConvertToBool(string value)
        {
            value =
                value.ToUpper().
                      Replace("YES", "TRUE").
                      Replace("Y", "TRUE").
                      Replace("1", "TRUE").
                      Replace("NO", "FALSE").
                      Replace("N", "FALSE").
                      Replace("0", "FALSE");
            bool result = false;
            bool.TryParse(value, out result);
            return result;
        }
        private class UnitConverter : Newtonsoft.Json.JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof (NewtonTest.IUnit).IsAssignableFrom(objectType);
            }
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue,
                                            Newtonsoft.Json.JsonSerializer serializer)
            {
                JObject obj = serializer.Deserialize<JToken>(reader) as JObject;
                if (obj != null)
                {
                    string result = obj["isSingleUnit"].ToObject<string>();
                    bool isSingleUnit = ConvertToBool(result);
                    string name = obj["name"].ToObject<string>();
                    if (isSingleUnit)
                    {
                        return new NewtonTest.House(name, isSingleUnit);
                    }
                    else
                    {
                        return new NewtonTest.Apartment(name, isSingleUnit);
                    }
                }
                else
                {
                    return null;
                }
            }
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value,
                                           Newtonsoft.Json.JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
        public static void Main()
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Converters.Add(new UnitConverter());
            string json =
                "{'Unit':[{'name':'Apartment 123',isSingleUnit:'no'},{'name':'House 456',isSingleUnit:'yes'}]}".Replace(
                    '\'', '\"');
            var obj = serializer.Deserialize(new StringReader(json), typeof (Data));
            Console.WriteLine(obj);
            Console.ReadKey();
        }
    }
    }
