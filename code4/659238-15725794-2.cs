        public bool isNullWhiteSpaceAndNotDecimal(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return true;
            }
            Decimal d;
            return !Decimal.TryParse(s, out d);
        }
        public bool isNullWhiteSpaceAndNotInt(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return true;
            }
            int i;
            return !Int32.TryParse(s, out i);
        }
