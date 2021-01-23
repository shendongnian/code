    public static class ColorExtensions
    {
        public static string GetColorString(this Color color)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in color.Name.ToCharArray())
            {
                if (char.IsUpper(c))
                    sb.Append(' ');
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
