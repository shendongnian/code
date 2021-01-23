    class Program
    {
        static void Main(string[] args)
        {
            EnumForEach<MyEnum>(MyMethod);
        }
        public static void EnumForEach<T>(Action<T> action)
        {
            if(!typeof(T).IsEnum)
                throw new ArgumentException("Generic argument type must be an Enum.");
            foreach (T value in Enum.GetValues(typeof(T)))
                action(value);
        }
        public static void MyMethod<T>(T enumValue)
        {
            Console.WriteLine(enumValue);
        }
    }
