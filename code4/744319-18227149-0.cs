    public static String GenerateEightCode( int codeLenght, Boolean isCaseSensitive)
        {
            char[] chars = GetCharsForCode(isCaseSensitive);
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[codeLenght];
            crypto.GetNonZeroBytes(data);
            StringBuilder sb = new StringBuilder(codeLenght);
            foreach (byte b in data)
            {
                sb.Append(chars[b % (chars.Length)]);
            }
            string key = sb.ToString();
            if (codeLenght == 8)
                key = key.Substring(0, 4) + "-" + key.Substring(4, 4);
            else if (codeLenght == 16)
                key = key.Substring(0, 4) + "-" + key.Substring(4, 4) + "-" + key.Substring(8, 4) + "-" + key.Substring(12, 4);
            return key.ToString();
        }
        private static char[] GetCharsForCode(Boolean isCaseSensitive)
        {
            // all - abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890
            char[] chars = new char[58];
            if (isCaseSensitive)
            {
                chars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ123456789".ToCharArray();//počet unikátních kombinací 4 - 424 270, 8 - 1 916 797 311, 16 - 7.99601828013E+13
            }
            else
            {
                chars = new char[35];
                chars = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789".ToCharArray();//počet unikátních kombinací 4 - 52 360, 8 - 23 535 820, 16 - 4 059 928 950
            }
            return chars;
        }
