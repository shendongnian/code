        public HastTable BuildRequestFromConditions(Conditions conditions)
        {
            var ht = new HashTable();
            var properties = conditions.GetType().GetProperties().Where(a => a.MemberType.Equals(MemberTypes.Property) && a.GetValue(conditions) != null);
            properties.ForEach(property => 
                {
                    var attribute = property.GetCustomAttribute(typeof(JsonPropertyAttribute));
                    var castAttribute = (JsonPropertyAttribute)attribute;
                    
                    ht.Add(castAttribute.PropertyName, property.GetValue(conditions));
                });
            return request;
        }
