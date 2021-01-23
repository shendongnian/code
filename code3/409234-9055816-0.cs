    List<object[]> array2D = new List<object[]>() { 
        new object[] { DateTime.Now.AddDays(-1000), 1578.55 }, 
        new object[] { DateTime.Now.AddDays(-2000), 566.5 },
        new object[] { DateTime.Now.AddDays(-3000), 480.88 },
        new object[] { DateTime.Now.AddDays(-4000), 509.84 } 
    };
    string jsonstr =  JsonConvert.SerializeObject(array2D,new MyDateTimeConvertor());
    public class MyDateTimeConvertor : Newtonsoft.Json.Converters.DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new Exception("Not implemented yet");
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(@"dd-MMM-yyy"));
        }
    }
