        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            decimal amount = arg is decimal ? (decimal) arg : 0;
            return amount.ToString("C", CultureInfo.CurrentCulture);
           
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double amount = 2541.25;
            var f = string.Format(new TestConvertor(), "{0:Currency}", 2545);
            Console.WriteLine(f);
            Console.ReadKey();
        }
    }
