    public static class ConvertEx
    {
        public static string ToStringEx(this int input, int baseVal, int sign)
        {
           var result = sign.ToString();
           result += Convert.ToString(input, baseVal);
           return result;
        }
    }
