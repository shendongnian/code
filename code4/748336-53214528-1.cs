     public partial class myModel
    {
        public static List<myModel> FromJson(string json) => JsonConvert.DeserializeObject<myModelList>(json, Converter.Settings).model;
    }
     public class myModelList {
        [JsonConverter(typeof(myModelConverter))]
        public List<myModel> model { get; set; }
    }
    class myModelConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var list = Activator.CreateInstance(objectType) as System.Collections.IList;
            var itemType = objectType.GenericTypeArguments[0];
            foreach (var child in token.Children())  //mod here
            {
                var newObject = Activator.CreateInstance(itemType);
                serializer.Populate(child.CreateReader(), newObject); //mod here
                list.Add(newObject);
            }
            return list;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && (objectType.GetGenericTypeDefinition() == typeof(List<>));
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
