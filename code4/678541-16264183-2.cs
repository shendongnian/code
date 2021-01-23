    public static class MongoEntityHelper
    {
        public static object GetAttributeValue<T>(IMongoEntity entity, string propertyName) where T : Attribute 
        {
            var attribute = (T)entity.GetType().GetCustomAttribute(typeof(T));
            return attribute != null ? attribute.GetType().GetProperty(propertyName).GetValue(attribute, null) : null;
        }
    }
