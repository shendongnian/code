        static string GetStringPropertyValue(dynamic d, string propertyName)
        {
            Type t = d.GetType();
            return t.GetProperty(propertyName).GetValue(d, null);
        }
