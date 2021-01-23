    public class CustomFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if(IsNumber(arg))
            {
                double number = Convert.ToDouble(arg);
                if(number < 1)
                    return string.Format("{0:0.000}", arg);
                else if(number < 10)
                    return string.Format("{0:0.00}", arg);
                return string.Format("{0:0}", arg);
            }
            else return string.Format(format,arg);  // default formatting for other types
        }
        
        public object GetFormat(Type formatType)
        {
        return (formatType == typeof(ICustomFormatter)) ? this : null;
        }
        
        public static bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
    
    void Main()
    {
        foreach(object val in (new object[] {0, 0.05, 1, 1.0, 1.5, 9.9, 10, 10m,0XFF}))
            Console.WriteLine(val + " : "+string.Format(new CustomFormatter(),"{0}",val));
    }
