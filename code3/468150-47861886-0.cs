            /// <summary>
            /// Returns a deep copy of an object.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="source"></param>
            /// <returns></returns>
            public static T DeepClone<T>(this T source) where T : class
            {
                if(source == null) return null;
    
                if(source is ICollection<object> col)
                {
                    return (T)DeepCloneCollection(col);
                }
                else if(source is IDictionary dict)
                {
                    return (T)DeepCloneDictionary(dict);
                }
    
                MethodInfo method = typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);
                T clone = (T)method.Invoke(source, null);
    
                foreach(FieldInfo field in source.GetType().GetRuntimeFields())
                {
                    if(field.IsStatic) continue;
                    if(field.FieldType.GetTypeInfo().IsPrimitive) continue;
    
                    object sourceValue = field.GetValue(source);
                    field.SetValue(clone, DeepClone(sourceValue));
                }
    
                return clone;
            }
    
            private static ICollection<object> DeepCloneCollection(ICollection<object> col)
            {
                object[] arry = (object[])Activator.CreateInstance(col.GetType(), new object[] { col.Count });
    
                for(int i = 0; i < col.Count; i++)
                {
                    object orig = col.ElementAt(i);
                    object cln = DeepClone(orig);
    
                    arry[i] = cln;
                }
    
                return arry;
            }
    
            private static IDictionary DeepCloneDictionary(IDictionary dict)
            {
                IDictionary clone = (IDictionary)Activator.CreateInstance(dict.GetType());
    
                foreach(object pair in dict)
                {
                    object key = pair.GetValueOf("Key");
                    object original = pair.GetValueOf("Value");
    
                    clone.Add(key, original.DeepClone());
                }
    
                return clone;
            }
            public static dynamic GetValueOf<T>(this T value, string property)
            {
                PropertyInfo p = value.GetType().GetTypeInfo().GetProperty(property);
    
                if(p != null && p.CanRead)
                {
                    dynamic val = p.GetValue(value);
    
                    return val;
                }
    
                return Activator.CreateInstance(p.PropertyType); //Property does not have  value, return default
            }
