        class Program
        {
            public static void Main(string[] args)
            {
                Type interfaceType = typeof(IGetStr);
                PropertyInfo[] propertyInfos = interfaceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                ClassA a = new ClassA("hello");
                foreach (PropertyInfo p in propertyInfos)
                {
                    var myValue = p.GetValue(a, null); // does not throw InvalidOperationException 
                }
            }
        }
        internal interface IGetStr
        {
            string StringValue { get; set; }
        }
        internal class ClassB<T> : IGetStr
        {
            public string str;
            public ClassB(string s)
            {
                str = s;
            }
            public string StringValue
            {
                get
                {
                    return str;
                }
                set
                {
                    str = value;
                }
            }
        }
        internal class ClassA : ClassB<String>
        {
            public ClassA(string value)
                : base(value)
            { }
        }
