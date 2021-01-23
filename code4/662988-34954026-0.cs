     public static string ToNULLString(this string Values)
            {
                if (string.IsNullOrEmpty(Values))
                {
                    return "";
                }
                else
                {
                    return Values.ToString();
                }
            }
