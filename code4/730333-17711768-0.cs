    public class RomanNumeral
        {
            public static int ToInt(string s)
            {
                var result = 0;
                var last = 0;
                s.Reverse().ToList().ForEach(c =>
                    {
                        var v = NumeralValue(c);
                        result += v >= last? v : -v;
                        last = v;
                    });
                return result;
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
