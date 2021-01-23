    public static class Int32Extensions
        {
            public static int? ParseOrDefault(this string text)
            {
                int iReturn = 0;
                if (int.TryParse(text, out iReturn))
                {
                    return iReturn;
                }
                return null;
            }
        }
