    using System;
    using System.Globalization;
    class FractionFormatter :ICustomFormatter, IFormatProvider
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Provide default formatting for unsupported argument types.
            if (!(arg is decimal))
            {
                HandleOtherFormats(format, arg);
            }
            // Provide default formatting for unsupported format strings.
            string ufmt = format.ToUpper(CultureInfo.InvariantCulture);
            if (ufmt != "H")
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            }
            decimal value = (decimal)arg;
            int wholeNumber = (int)Math.Floor(value);
            decimal fraction = value - (decimal)wholeNumber;
            if (fraction == 0m)
            {
                return wholeNumber.ToString();
            }
            else if (fraction == 0.5m)
            {
                if (wholeNumber == 0)
                {
                    return "1/2";
                }
                else
                {
                    return wholeNumber.ToString() + " 1/2";
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("arg", "Value must be a multiple of 0.5");
            }
            
        }
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
