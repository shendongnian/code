        private void updateSelf(MongoDoc newDoc, Type type)
        {
            foreach (var i in type.GetProperties(BindingFlags.DeclaredOnly))
            {
                if (i.GetCustomAttributes(false).Any(x => x is MongoDB.Bson.Serialization.Attributes.BsonIgnoreAttribute)) continue;
                Object oldValue = i.GetValue(this, null);
                Object newValue = i.GetValue(newDoc, null);
                if (!Object.Equals(oldValue, newValue) && !((oldValue == null) && (newValue == null)))
                {
                    i.SetValue(this, newValue, null);
                }
                Type baseType = type.BaseType;
                if (baseType != null)
                {
                    this.updateSelf(newDoc, baseType);
                }
            }
        }
