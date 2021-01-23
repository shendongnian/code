    public static bool TryAddValue<TKey,TValue>(this System.Collections.Generic.IDictionary<TKey,List<TValue>> dictionary, TKey key, TValue value)
        {
            // Null check (useful or not, depending on your null checking approach)
            if (value == null)
                return false;
            List<TValue> tempValue = default(List<TValue>);
            try
            {
                if (!dictionary.TryGetValue(key, out tempValue))
                {
                    dictionary.Add(key, tempValue = new List<TValue>());
                }
                else
                {
                    // Double null check (useful or not, depending on your null checking approach)
                    if (tempValue == null)
                    {
                        dictionary[key] = (tempValue = new List<TValue>());
                    }
                }
                tempValue.Add(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
