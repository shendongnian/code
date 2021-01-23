    public static class BigRationalExtensions
    {
        public static string ToDecimalString(this BigRational r, int numDigits)
        {
            var fraction = r.GetFractionPart();
            var adjustedNumerator = (fraction.Numerator 
                                          * BigInteger.Pow(10, numDigits));
            var decimalPlaces = adjustedNumerator / fraction.Denominator;
            // Give it the capacity for around what we should need for 
            // the whole part and total precision 
            // (this is kinda sloppy, but does the trick)
            var sb = new StringBuilder(numDigits + r.ToString().Length);
            bool noMoreTrailingZeros = false;
            for (int i = numDigits; i > 0; i--)
            {
                if(!noMoreTrailingZeros)
                {
                    if ((decimalPlaces%10) == 0)
                    {
                        decimalPlaces = decimalPlaces/10;
                        continue;
                    }
                    noMoreTrailingZeros = true;
                }
                // Add the right most decimal to the string
                sb.Insert(0, decimalPlaces%10);
                decimalPlaces = decimalPlaces/10;
            }
            // If the precision wasn't high enough, sb will
            // have a length of 0.
            if(sb.Length == 0)
            {
                return "0.0";
            }
            // Insert the whole part and decimal
            sb.Insert(0, ".");
            sb.Insert(0, r.GetWholePart());
            return sb.ToString();
        }
    }
