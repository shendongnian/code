        public List<string> GetEmptyStringAttributes()
        {
            List<string> emptyStringAttributes = new List<string>();
            Type type = this.GetType();
            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                if (property.PropertyType == typeof(String))
                {
                    string value = property.GetValue(this) as string;
                    if (string.IsNullOrWhiteSpace(value))
                        emptyStringAttributes.Add(property.Name);
                }
            }
            return emptyStringAttributes;
        }
    }
