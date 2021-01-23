    int val = 456;
    string s = string.Format(new CustomerFormatter(),"{0}", val);
    Console.WriteLine(s); //45.6
              
     public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                return null;
            }
            else
            {
                string customerString = arg.ToString();
                return customerString.Insert(customerString.Length - 1, "."); 
            }
        }
    }
