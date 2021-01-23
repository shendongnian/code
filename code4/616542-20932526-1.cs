        private string Decode(string UnicodeString)
        {
            Regex DECODING_REGEX = new Regex(@"\\u(?<Value>[a-fA-F0-9]{4})", RegexOptions.Compiled);
            string PLACEHOLDER = @"#!#";
            return DECODING_REGEX.Replace(UnicodeString.Replace(@"\\", PLACEHOLDER),
            m =>
            {
                return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
            })
            .Replace(PLACEHOLDER, @"\\");
        }
