    public class RomanNumeral
        {
            public static int ToInt(string s)
            {
                  var last = 0;
                  return s.Reverse().Select(NumeralValue).Sum(v =>
                  {                    
                    var r = (v >= last)? v : -v;
                    last = v;
                    return r;
                  });
            }
    
            private static int NumeralValue(char c)
            {
                switch (c)
                {
                    case 'I': return 1;
                    case 'V': return 5;
                    case 'X': return 10;
                    case 'L': return 50;
                    case 'C': return 100;
                    case 'D': return 500;
                    case 'M': return 1000;                    
                }
                return 0;
            }
        }
