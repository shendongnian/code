    class MyFormatProvider : IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            return "G";
        }
    }
    static void Main(string[] args)
    {
        Nullable<int> SomeProperty = 1000000;
        Console.WriteLine(SomeProperty.ToString());
        Console.WriteLine(Convert.ToString(SomeProperty));
        Console.WriteLine(Convert.ToString(SomeProperty, new MyFormatProvider()));
    }
    
