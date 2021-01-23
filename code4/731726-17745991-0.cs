     public static T DeserializeFromJson<T>(string json)
        {
            T deserializedProduct = JsonConvert.DeserializeObject<T>(json);
            return deserializedProduct;
        }
     var container = DeserializeFromJson<ClassName>(JsonString);
