    private void WalkDictionary(IDictionary dict, object obj)
    {
        foreach (string key in dict.Keys)
        {
            Type t = obj.GetType();
            if (t.IsGenericType
                && typeof(List<>) == t.GetGenericTypeDefinition())
            {
                Type[] typeParameters = t.GetGenericArguments();
                foreach (DictionaryEntry item in dict)
                {
                    var lstPropObj = Activator.CreateInstance(typeParameters[0]);
                    WalkDictionary((IDictionary)item.Value, lstPropObj);
                    ((IList)obj).Add(lstPropObj);
                }
                return;
            }
            PropertyInfo prop = obj.GetType().GetProperty(key);
            if (prop == null)
                continue;
            if (dict[key] is IDictionary)
            {
                //Walk
                var objProp = prop.GetValue(obj);
                if (objProp == null)
                    objProp = Activator.CreateInstance(prop.PropertyType);
                WalkDictionary(dict[key] as IDictionary, objProp);
                prop.SetValue(obj, objProp);
            }
            else if (prop.PropertyType.IsAssignableFrom(typeof(int)))
            {
                int val = Convert.ToInt32(dict[key]);
                prop.SetValue(obj, val);
            }
            else if (prop.PropertyType.IsAssignableFrom(typeof(bool)))
            {
                bool val = Convert.ToBoolean(dict[key]);
                prop.SetValue(obj, val);
            }
            else if (prop.PropertyType.IsAssignableFrom(typeof(string)))
            {
                string val = Convert.ToString(dict[key]);
                prop.SetValue(obj, val);
            }
        }
    }
