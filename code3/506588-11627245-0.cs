    public static bool Contains(this string value, string[] values)
        {
            foreach (string comparar in values)
            {
                if (value.ToUpper().Contains(comparar.ToUpper())) return true;
            }
            return false;
        }
