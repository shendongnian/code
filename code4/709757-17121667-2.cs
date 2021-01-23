    public class TranslateDictionary<TKey, TValue>
    {
        public bool Initialized { get; set; }
        private Dictionary<TKey, TValue> Dictionary = new Dictionary<TKey,TValue>();
        public TValue this[TKey lang]
        {
            get
            {
                if (!Initialized)
                {
                    if (!Dictionary.ContainsKey(lang))
                    {
                        Dictionary.Add(lang, Activator.CreateInstance<TValue>());
                    }
                }
                return Dictionary[lang];
            }
            set
            {
                Dictionary[lang] = value;
            }
        }
    }
