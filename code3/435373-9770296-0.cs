    class AnnotatedObject<T>
    {
        private Dictionary<string, bool> _propertyMap =
            new Dictionary<string, bool>();
        public AnnotatedObject(T originalObject) { OriginalObject = originalObject; }
        public T OriginalObject { get; private set; }
        public bool IsCorrect[string property]
        {
            get
            {
                bool result;
                if(!_propertyMap.TryGetValue(property, out result))
                    result = false;
                return result;
            }
            set { _propertyMap[property] = value; }
        }
    }
