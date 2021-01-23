    public static class HtmlExtensions
    {
        public static string Truncate(this HtmlHelper html, string value, int count)
        {
            if (string.IsNullOrEmpry(value))
            {
                return string.Empty;
            }
    
            if (value.Length > count)
            {
                value = value.Substring(0, count - 1) + "...";
            }
               
            return value;
        }
    }
