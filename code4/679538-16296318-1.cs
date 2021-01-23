    class TreeNodeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // we can serialize everything that is a TreeNode
            return typeof(TreeNode).IsAssignableFrom(objectType);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // we currently support only writing of JSON
            throw new NotImplementedException();
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // we serialize a node by just serializing the _children dictionary
            var node = value as TreeNode;
            serializer.Serialize(writer, node._children);
        }
    }
