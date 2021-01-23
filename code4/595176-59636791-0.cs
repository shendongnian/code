     public static string GetTextBetween(this string value, string startTag, string endTag, StringComparison stringComparison = StringComparison.CurrentCulture)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int startIndex = value.IndexOf(startTag, stringComparison) + startTag.Length;
                if (startIndex > -0)
                {
                    var endIndex = value.IndexOf(endTag, startIndex, stringComparison);
                    if (endIndex > 0)
                    {
                        return value.Substring(startIndex, endIndex - startIndex);
                    }
                }
            }
            return null;
        }
 
