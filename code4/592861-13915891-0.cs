    public static class CssStyle
    {
        public static string Update(string style, string key, string value)
        {
            var parts = style.Split(';');
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].StartsWith(key))
                {
                    parts[i] = key + ":" + value;
                    break;
                }
            }
            return string.Join(";", parts);
        }
    }
