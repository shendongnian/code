    [Serializable]
    public abstract class DefaultableValue<T>
    {
        protected Func<string, T> _parsingFunc;
        private string _valueText;
        private T _cachedValue;
        private bool _isValueCached;
        private string _defaultText;
        private T _cachedDefault;
        private bool _isDefaultCached;
        protected DefaultableValue(Func<string, T> parsingFunc)
        {
            _parsingFunc = parsingFunc;
            _isValueCached = false;
            _isDefaultCached = false;
        }
        [XmlAttribute("default")]
        public string DefaultText
        {
            get { return _defaultText; }
            set
            {
                _defaultText = value;
                _isDefaultCached = false;
            }
        }
        [XmlText]
        public string ValueText
        {
            get { return _valueText; }
            set
            {
                _valueText = value;
                _isValueCached = false;
            }
        }
        [XmlIgnore]
        public T Default
        {
            get
            {
                if (_isDefaultCached)
                    return _cachedDefault;
                if (HasDefault)
                    return ParseAndCacheValue(DefaultText, out _cachedDefault, out _isDefaultCached);
                return default(T);
            }
            set
            {
                DefaultText = value.ToString();
                _cachedDefault = value;
                _isDefaultCached = true;
            }
        }
        [XmlIgnore]
        public T Value
        {
            get
            {
                if (_isValueCached)
                    return _cachedValue;
                if (HasValue)
                    return ParseAndCacheValue(ValueText, out _cachedValue, out _isValueCached);
                return Default;
            }
            set
            {
                ValueText = value.ToString();
                _cachedValue = value;
                _isValueCached = true;
            }
        }
        [XmlIgnore]
        public bool HasDefault { get { return !string.IsNullOrEmpty(_defaultText); } }
        [XmlIgnore]
        public bool HasValue { get { return !string.IsNullOrEmpty(_valueText); } }
        private T ParseAndCacheValue(string text, out T cache, out bool isCached)
        {
            cache = _parsingFunc(text);
            isCached = true;
            return cache;
        }
    }
