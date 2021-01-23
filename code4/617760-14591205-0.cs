        public static decimal? ToNullableDecimal(object val)
        {
            if (val is DBNull ||
                val == null)
            {
                return null;
            }
            if (val is string &&
                ((string)val).Length == 0)
            {
                return null;
            }
            return Convert.ToDecimal(val);
        } 
