    public struct RationalNumber : IEquatable<RationalNumber>
    {
        private readonly long numerator;
        private readonly long denominator;
        public RationalNumber(long numerator, long denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
    
        public bool IsZero 
        { 
           get { return numerator == 0; }
        }
        public bool IsInvalid 
        { 
           get { return denominator == 0 && numerator != 0; }
        }
        
        public bool Equals(RationalNumber r)
        {
           if (r.IsZero && IsZero)
             return true;
           if (r.IsInvalid && IsInvalid)
             return true;
           return denominator == r.denominator && numerator == r.numerator;
        }
        public bool Equals(object o)
        {
           if (!(o is RationalNumber))
             return false;
           return Equals((RationalNumber)o);
        }
        public int GetHashCode()
        {
           if (IsZero) 
             return 0;
           if (IsInvalid)
             return Int32.MinValue;
           return ((float)numerator/denominator).GetHashCode();
        }
    }   
