    public static class StringExtensions
    {
        public static string TrimCrLf(this string value)
        {
            return Regex.Replace(value, @"^[\r\n\t ]+|[\r\n\t ]+$", "");
        }
    }
    // Use it like:
    newEle.ProductName = reader.ReadString().TrimCrLf();
