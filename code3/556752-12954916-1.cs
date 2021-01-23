    public static class StringExtensions
    {
        public static string Rewrite(this string input, string replacement, int index)
        {
            var output = new System.Text.StringBuilder();
            output.Append(input.Substring(0, index));
            output.Append(replacement);
            output.Append(input.Substring(index + replacement.Length));
            return output.ToString();
        }
    }
