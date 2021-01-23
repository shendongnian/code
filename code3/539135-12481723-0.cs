        string GetFullIpFormat(string value)
        {
            string[] ip = new string[4];
            for (int i = 0; i < ip.Length; i++)
            {
                ip[i] = GetIpPart(i, value);
            }
            return string.Format("{0:###}.{1:###}.{2:###}.{3:###}", ip[0], ip[1], ip[2], ip[3]);
        }
        string GetIpPart(int partNumber, string ip)
        {
            string result = "000";
            int iLen = 3;
            ip = ip.Replace(".", "");
            int iStart = partNumber * iLen;
            if (ip.Length > iStart)
            {
                result = ip.Substring(iStart);
                if (result.Length > iLen)
                {
                    result = result.Substring(0, iLen);
                }
            }
            return result;
        }
