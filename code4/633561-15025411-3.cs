    public static class ExtendInt32
    {
        public static bool TryConvertToShort(this int value, out short result)
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
