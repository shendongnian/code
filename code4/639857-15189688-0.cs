    public static class Extensions {
        public static decimal MyDecimalParse(this string val) { 
            decimal ret = decimal.Zero;
            decimal.TryParse(val, out ret);
            return ret;
        }
    } // eo class extension
