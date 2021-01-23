        public class DictionaryComparer<TKey,TValue>: EqualityComparer<Dictionary<TKey,TValue>>
        {
            public override bool Equals(Dictionary<TKey, TValue> x, Dictionary<TKey, TValue> y)
            {
                //True if both sequences of KeyValuePair items are equal
                var sequenceEqual = x.SequenceEqual(y);
                return sequenceEqual;
            }
            public override int GetHashCode(Dictionary<TKey, TValue> obj)
            {
                //Quickly detect differences in size, defer to Equals for dictionaries 
                //with matching sizes
                return obj.Count;
            }
        }
