    public static string ConvertToXmlCharacterReference(string xml)
        {
            StringBuilder sb = new StringBuilder();
            const char SP = '\u0020'; // anything lower than SP is a control character
            const char DEL = '\u007F'; // anything above DEL isn't ASCII, per se.
            int i = 0;
            foreach (char ch in xml)
            {
                bool isPrintableAscii = ch >= SP && ch <= DEL;
                if (isPrintableAscii)
                {
                    sb.Append(ch);
                }
                else
                {
                    sb.AppendFormat("&#x{0:X4};", (int) ch);
                }
            }
            string instance = sb.ToString();
            return instance;
        }
