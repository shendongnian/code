    public static string AllowedChars(string str, IEnumerable<char> toInclude)
    {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (toInclude.Contains(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
