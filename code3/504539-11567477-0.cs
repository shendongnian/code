        static T ReadSetting<T>(string value)
        {
            object valueObj = null;
            if (typeof(T) == typeof(Int32))
                valueObj = Int32.Parse(value);
            return (T)valueObj;
        }
        static dynamic ReadSetting2<T>(string value)
        {
            if (typeof(T) == typeof(Int32))
                return Int32.Parse(value);
            throw new UnsupportedException("Type is unsupported");
        }
        static void Main(string[] args)
        {
            int val1 = ReadSetting<Int32>("2");
            int val2 = ReadSetting2<Int32>("3");
        }
