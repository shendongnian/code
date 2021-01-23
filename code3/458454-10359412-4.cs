    public static class BigRationalExtensions
    {
        public static string ToDecimalString(this BigRational r, int precision)
        {
            var fraction = r.GetFractionPart();
            // Case where the rational number is a whole number
            if(fraction.Numerator == 0 && fraction.Denominator == 1)
            {
                return r.GetWholePart() + ".0";
            }
            var adjustedNumerator = (fraction.Numerator
                                               * BigInteger.Pow(10, precision));
            var decimalPlaces = adjustedNumerator / fraction.Denominator;
            // Case where precision wasn't large enough.
            if(decimalPlaces == 0)
            {
                return "0.0";
            }
            // Give it the capacity for around what we should need for 
            // the whole part and total precision
            // (this is kinda sloppy, but does the trick)
            var sb = new StringBuilder(precision + r.ToString().Length);
            bool noMoreTrailingZeros = false;
            for (int i = precision; i > 0; i--)
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
            // Insert the whole part and decimal
            sb.Insert(0, ".");
            sb.Insert(0, r.GetWholePart());
            return sb.ToString();
        }
    }
