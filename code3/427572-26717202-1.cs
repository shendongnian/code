     public class DecimalAttribute : RegularExpressionAttribute
     {
        public int DecimalPlaces { get; set; }
        public DecimalAttribute(int decimalPlaces)
            : base(string.Format(@"^\d*\.?\d{{0,{0}}}$", decimalPlaces))
        {
            DecimalPlaces = decimalPlaces;
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format("This number can have maximum {0} decimal places", DecimalPlaces);
        }
     }
