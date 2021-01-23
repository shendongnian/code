    public class PostsConverter : JsonConverter
    {
    
        // Create an instance
        protected IPost Create(JObject jObject)
        {
            if (PostType("Text", jObject))  return new Text();
            if (PostType("Video", jObject))  return new Video();
            throw new Exception("Error");
        }
    
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var list = new List<IPost>();
    
            var arr = JArray.Load(reader);
    
            foreach (var item in arr)
            {
                var obj = JObject.Load(item.CreateReader());
    
                // Create target object based on JObject
                var post = Create(obj);
    
                // Populate the object properties
                serializer.Populate(obj.CreateReader(), post);
    
                list.Add(post);
            }
            return list;
        }
    
        private bool PostType(string type, JObject jObject)
        {
            return jObject["PostType"] != null && jObject["PostType"].Value<string>() == type;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // I don't need serialize object
            throw new NotImplementedException();
        }
    }
