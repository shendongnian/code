    public static class StringExtension
    {
        public static string Repeat(this string text, int times)
        {
            string Return = string.Empty;
            
            if (times > 0)
            {
                for (int i = 0; i < times; i++)
                {
                    Return = string.Concat(Return, text);
                }
            }
            return Return;
        }
    }
