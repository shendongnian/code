        public bool isDecimal(string s)
        {
            Decimal d;
            return Decimal.TryParse(s, out d);
        }
        public bool isInt(string s)
        {
            int i;
            return Int32.TryParse(s, out i);
        }
