    static void Main(string[] args)
    {
        try
        {
            string a = Cast<string>(1);
        }
        catch (InvalidCastExceptionEx ex)
        {
            Console.WriteLine("Failed to convert from {0} to {1}.", ex.FromType, ex.ToType);
        }
    }
    public class InvalidCastExceptionEx : InvalidCastException
    {
        public Type FromType { get; private set; }
        public Type ToType { get; private set; }
        public InvalidCastExceptionEx(Type fromType, Type toType)
        {
            FromType = fromType;
            ToType = toType;
        }
    }
    static ToType Cast<ToType>(object value)
    {
        try
        {
            return (ToType)value;
        }
        catch (InvalidCastException)
        {
            throw new InvalidCastExceptionEx(value.GetType(), typeof(ToType));
        }
    }
