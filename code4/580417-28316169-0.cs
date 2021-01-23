        public static int GetLowestDenominator(int a, int b, int c = 2)
        { 
            if (a == 1 | b == 1) {
                return 1;
            }
            else if (a % c == 0 & b % c == 0)
            {
                return c;
            }
            else if (c < a & c < b)
            {
                c += 1;
                return GetLowestDenominator(a, b, c);
            }
            else
            {
                return 0;
            }
        }
