    int val = 456;  
    string s = string.Format(new CustomerFormatter(),"{0:1d}", val);
    string s1 = string.Format(new CustomerFormatter(), "{0:2d}", val);
    Console.WriteLine(s); //45.6
    Console.WriteLine(s1); //4.56
              
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
                 switch (format)
                {
                    case "1d":
                        return customerString.Insert(customerString.Length - 1, ".");
                    case "2d":
                        return customerString.Insert(customerString.Length - 2, ".");
                    default:
                        return customerString;
                }
            }
        }
    }
