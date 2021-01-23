            public static string ExtractHexDigits(string input)
            {
                // remove any characters that are not digits (like #)
                var isHexDigit
                    = new Regex("[abcdefABCDEF\\d]+", RegexOptions.Compiled);
                string newnum = "";
                foreach (char c in input)
                {
                    if (isHexDigit.IsMatch(c.ToString()))
                    {
                        newnum += c.ToString();
                    }
                }
                return newnum;
            }
