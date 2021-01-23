    public static class BigRationalExtensions
    {
        public static string ToDecimalString(this BigRational r, int numDigits)
        {
            var fraction = r.GetFractionPart();
            var adjustedNumerator = (fraction.Numerator 
                                          * BigInteger.Pow(10, numDigits));
            var decimalPlaces = adjustedNumerator / fraction.Denominator;
            return r.GetWholePart() + "." + decimalPlaces;
        }
    }
    var r = new BigRational(50000, 3768);
    Console.WriteLine(r.ToDecimalString(1000));
