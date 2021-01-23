    public static class Number
    {
        public static bool TryConvert(int value, out short result)
        {
            bool retval = false;
            result = 0;
            if (value > Int16.MinValue && value < Int16.MaxValue)
            {
                result = Convert.ToInt16(value);
                retval = true;
            }
            
            return retval;
        }
    }
