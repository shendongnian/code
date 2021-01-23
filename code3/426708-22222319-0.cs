    public static string JavaScriptStringDecode(string source)
    {
        // Replace some chars.
        var decoded = source.Replace(@"\'", "'")
                    .Replace(@"\""", @"""")
                    .Replace(@"\/", "/")
                    .Replace(@"\\", @"\")
                    .Replace(@"\t", "\t")
                    .Replace(@"\n", "\n");
     
        // Replace unicode escaped text.
        var rx = new Regex(@"\\[uU]([0-9A-F]{4})");
     
        decoded = rx.Replace(decoded, match => ((char)Int32.Parse(match.Value.Substring(2), NumberStyles.HexNumber))
                                                .ToString(CultureInfo.InvariantCulture));
     
        return decoded;
    }
