        public bool? Intubated_1 {get; set; }
        public bool? Intubated_2 {get; set; }
        public bool? Intubated_3 {get; set; }
        public bool? Intubated_4 {get; set; }
        public bool? Intubated_5 {get; set; }
        public List<bool?> NullableBoolPropertiesList()
        {
            List<bool?> properties = new List<bool?>();
            Type type = this.GetType();
            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                if (property.PropertyType == typeof(bool?))
                {
                    bool? value = property.GetValue(this) as bool?;
                    properties.Add(value);
                }
            }
            return properties;
        }
