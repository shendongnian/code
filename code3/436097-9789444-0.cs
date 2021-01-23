        foreach(PropertyInfo p in item.GetType().GetProperties())
        {
            if (p.PropertyType.BaseType == typeof(ValueType))
            {
                var originalValue = p.GetValue(original, null);
                var modifiedValue = p.GetValue(item, null);
                if (!originalValue.Equals(modifiedValue)) kvpData.AppendFormat("{0}={1}&", p.Name, originalValue);
            }
         } 
