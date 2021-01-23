        using System;
      using System.Collections.Generic;
     using System.IO;
     using System.Linq;
    using Newtonsoft.Json;
    namespace NewtonTest
     {
    namespace NewtonTest
    {
        internal class Program
        {
            public class Data
            {
                public IEnumerable<IUnit> Unit { get; set; }
                public override string ToString()
                {
                    return string.Format("Data{{Unit=[{0}]}}",
                                         string.Join(", ",
                                                     Unit.Select(
                                                         c =>
                                                         string.Format("{0}/{1}", c.Name, c.isSingleUnit ? "House" : "Apartment"))));
                }
            }
            public interface IUnit
            {
                string Name { get; }
                [JsonConverter(typeof(MyBooleanConverter))]
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
                public bool isSingleUnit { get; private set;  }
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
            public sealed class MyBooleanConverter : JsonConverter
            {
                public override bool CanWrite
                {
                    get { return false; }
                }
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                                JsonSerializer serializer)
                {
                    var value = reader.Value;
                    if (value == null || String.IsNullOrWhiteSpace(value.ToString()))
                    {
                        return false;
                    }
                    if (value.ToString().Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                    return false;
                }
                public override bool CanConvert(Type objectType)
                {
                    if (objectType == typeof (String) || objectType == typeof (Boolean))
                    {
                        return true;
                    }
                    return false;
                }
            }
            public static void Main()
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Converters.Add(new MyBooleanConverter());
                string json = "{'Unit':[{'name':'Apartment 123',isSingleUnit:'no'},{'name':'House 456',isSingleUnit:'yes'}]}".Replace('\'', '\"');
                var obj = serializer.Deserialize(new StringReader(json), typeof(bool));
                Console.WriteLine(obj);
                Console.ReadKey();
            }
        }
    }
}
