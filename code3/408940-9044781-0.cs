    class TypeDictionary : IDictionary<string, Type>
    {
        private readonly Type m_typeToLimit;
        readonly IDictionary<string, Type> m_dictionary =
            new Dictionary<string, Type>();
        public TypeDictionary(Type typeToLimit)
        {
            m_typeToLimit = typeToLimit;
        }
        public void Add(string key, Type value)
        {
            if (!m_typeToLimit.IsAssignableFrom(value))
                throw new InvalidOperationException();
            m_dictionary.Add(key, value);
        }
        public int Count
        {
            get { return m_dictionary.Count; }
        }
        public void Clear()
        {
            m_dictionary.Clear();
        }
        // the rest of members of IDictionary
    }
