    class ConfigValue
    {
        public string paramPath;
        private string paramValue;
        public T PolimorphProperty<T>()
        {
            return (T)Convert.ChangeType(paramValue, typeof(T));
        }
    }
