        static object GetData(object obj, string propName)
        {
            string[] propertyNames = propName.Split('.');
            foreach (string propertyName in propertyNames)
            {
                string name = propertyName;
                var pi = obj
                    .GetType()
                    .GetProperties()
                    .SingleOrDefault(p => p.Name == name);
                if (pi == null)
                {
                    throw new Exception("Property not found");
                }
                obj = pi.GetValue(obj);
            }
            return obj;
        }
