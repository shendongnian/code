        public static string SimpleXOR(string strIn, string strKey)
        {
            if (strIn.Length == 0 || strKey.Length == 0)
            {
                return string.Empty;
            }
            int inIndex = 0;
            int keyIndex = 0;
            string returnString = string.Empty;
            var currentCodePage = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ANSICodePage;
            var encoding = Encoding.GetEncoding(currentCodePage);
            var inString = encoding.GetBytes(strIn);
            var keyString = encoding.GetBytes(strKey);
            while (inIndex < inString.Length)
            {
                returnString += (char)(inString[inIndex] ^ keyString[keyIndex]);
                inIndex++;
                if (keyIndex == keyString.Length - 1)
                {
                    keyIndex = 0;
                }
                else
                {
                    keyIndex++;
                }
            }
            return returnString;
        }
