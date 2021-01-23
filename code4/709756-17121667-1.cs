    public class TranslateDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> Dictionary = new Dictionary<TKey,TValue>();
        public TValue this[TKey lang]
        {
            get
            {
                if (!Dictionary.ContainsKey(lang))
                {
                    Dictionary.Add(lang, Activator.CreateInstance<TValue>());
                }
                return Dictionary[lang];
            }
            set
            {
                Dictionary[lang] = value;
            }
        }
    }
