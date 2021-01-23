        public static bool IsNumeric(this object value)
        {
            if (value == null || value is DateTime)
            {
                return false;
            }
    
            if (value is Int16 || value is Int32 || value is Int64 || value is Decimal || value is Single || value is Double || value is Boolean)
            {
                return true;
            }
    
            try
            {
                if (value is string)
                    Double.Parse(value as string);
                else
                    Double.Parse(value.ToString());
                return true;
            }
            catch { }
            return false;
        }
