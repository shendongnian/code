    class ConfigValue
    {
        public string paramPath;
        private string paramValue;
        public T PolimorphProperty<T>()
        {
            if (typeof(T) == typeof(MySpecialType))
                return (T)(object)new MySpecialType(paramValue);
            else
                return (T)Convert.ChangeType(paramValue, typeof(T));
        }
    }
