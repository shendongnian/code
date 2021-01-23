    /// <summary>
    /// Escapes all characters in this string whose code is less than 32 using C/C#-compatible backslash escapes.
    /// </summary>
    public static string CLiteralEscape(this string value)
    {
        if (value == null)
            throw new ArgumentNullException("value");
        var result = new StringBuilder(value.Length + value.Length / 2);
        for (int i = 0; i < value.Length; i++)
        {
            char c = value[i];
            switch (c)
            {
                case '\0': result.Append(@"\0"); break;
                case '\a': result.Append(@"\a"); break;
                case '\b': result.Append(@"\b"); break;
                case '\t': result.Append(@"\t"); break;
                case '\n': result.Append(@"\n"); break;
                case '\v': result.Append(@"\v"); break;
                case '\f': result.Append(@"\f"); break;
                case '\r': result.Append(@"\r"); break;
                case '\\': result.Append(@"\\"); break;
                case '"': result.Append(@"\"""); break;
                default:
                    if (c >= ' ')
                        result.Append(c);
                    else // the character is in the 0..31 range
                        result.AppendFormat(@"\x{0:X2}", (int) c);
                    break;
            }
        }
        return result.ToString();
    }
