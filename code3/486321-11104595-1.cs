    public class One : Base<string, string>
    {
        public One(string key, string value)
            : base(key, value, () => MyLookups.DefaultValues)
        {
        }
    }
    public class Two : Base<string, string>
    {
        public Two(string key, string value)
            : base(key, value, () => MyLookups.Acronyms)
        {
        }
    }
    
    public abstract class Base<TKey, TValue>
    {
        protected Base(TKey key, TValue value, Func<IDictionary<TKey, TValue>> getDictionary) 
        {
            var dictionary = getDictionary();
            dictionary.Add(key, value);
        }
    }
