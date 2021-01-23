        private static Dictionary<TKey, TValue> ObjectToDictionary<TKey, TValue>(object source)
        {
            Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
            TKey[] keys = { };
            TValue[] values = { };
            bool outLoopingKeys = false, outLoopingValues = false;
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);
                if (value is Dictionary<TKey, TValue>.KeyCollection)
                {
                    keys = ((Dictionary<TKey, TValue>.KeyCollection)value).ToArray();
                    outLoopingKeys = true;
                }
                if (value is Dictionary<TKey, TValue>.ValueCollection)
                {
                    values = ((Dictionary<TKey, TValue>.ValueCollection)value).ToArray();
                    outLoopingValues = true;
                }
                if(outLoopingKeys & outLoopingValues)
                {
                    break;
                }
            }
            for (int i = 0; i < keys.Length; i++)
            {
                result.Add(keys[i], values[i]);
            }
            return result;
        }
