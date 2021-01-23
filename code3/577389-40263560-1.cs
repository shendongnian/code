    public static int IndexOf<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value) 
        {
            int i = 0;
            foreach(var pair in dictionary)
            {
                if(pair.Value.Equals(value))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
