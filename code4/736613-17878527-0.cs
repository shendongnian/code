        private static bool IsValidISO(string input)
        {
            foreach (char c in input)
            {
                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                Encoding utf8 = Encoding.UTF8;
                byte[] isoBytes = iso.GetBytes(c.ToString());
                byte[] utfBytes = Encoding.Convert(iso, utf8, isoBytes);
                string convertedC = utf8.GetString(utfBytes);
                if (c != '?' && convertedC == "?")
                    return false;
            }
            return true;
        }
