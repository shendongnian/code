    public static class BaseClassFactory
    {
        public static BaseClass Create(string input)
        {
            if (input.Substring(0, 5) == "Something")
                return new DerivedClass();
            return new BaseClass();
        }
    }
