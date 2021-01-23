      public class BaseX
        {
            private readonly string _digits;
    
            public BaseX(string digits)
            {
                _digits = digits;
            }
            public string ToBaseX(int number)
            {           
                var output = "";
                do
                {                
                    output = _digits[number % _digits.Length] + output;
                    number = number / _digits.Length;
                }
                while (number > 0);
                return output;
            }
    
            public int FromBaseX(string number)
            {
                return number.Aggregate(0, (a, c) => a*_digits.Length + _digits.IndexOf(c));
            }
        }
