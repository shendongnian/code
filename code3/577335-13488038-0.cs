        class Base { }
        class Derived0 : Base { }
        class Derived1 : Base { }
        class Program {
            static void Main(string[] args) {
                var d0 = new Dictionary<string, Derived0>();
                var d1 = new Dictionary<string, Derived1>();
                var b = d0.Merge<string, Derived0, Derived1, Base>(d1);
            }
        }
    
        public static class DictionaryExtensions {
            public static Dictionary<TKey, TBase> Merge<TKey, TValue1, TValue2, TBase>(this IDictionary<TKey, TValue1> thisDictionary, IDictionary<TKey, TValue2> thatDictionary)
                where TValue1 : TBase
                where TValue2 : TBase {
                var resultDictionary = new Dictionary<TKey, TBase>();
                resultDictionary.AddRange(thisDictionary);
                resultDictionary.AddRange(thatDictionary);
    
                return resultDictionary;
            }
    
            public static void AddRange<TKey, TBase, TValue>(this IDictionary<TKey, TBase> dictionary, IDictionary<TKey, TValue> dictionaryToAdd) where TValue : TBase {
                foreach (var kvp in dictionaryToAdd) {
                    dictionary.Add(kvp.Key, kvp.Value);
                }
            }
        }
