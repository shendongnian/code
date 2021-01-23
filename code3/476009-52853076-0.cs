        public static string Decode(string s)
        {
            return String.Join("", Regex.Matches(s ?? "", @"(?:=\?)([^\?]+)(?:\?B\?)([^\?]*)(?:\?=)").Cast<Match>().Select(m =>
            {
                string charset = m.Groups[1].Value;
                string data = m.Groups[2].Value;
                byte[] b = Convert.FromBase64String(data);
                return Encoding.GetEncoding(charset).GetString(b);
            }));
        }
