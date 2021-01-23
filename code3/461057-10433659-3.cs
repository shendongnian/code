        public class DictionaryConverter
        {
            public static Dictionary<string,TValue> 
                ConvertDictionary<TKey,TValue>(Dictionary<TKey,TValue> dict)
            {
                Dictionary<string,TValue> newDict
                    = new Dictionary<string, TValue>();
                foreach(TKey key in dict.Keys)
                {
                    newDict.Add(key.ToString(), dict[key]);
                }
                return newDict;
            }
        }
