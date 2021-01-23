    public static string Encode7bit(string s)
            {
                string empty = string.Empty;
                for (int index = s.Length - 1; index >= 0; --index)
                    empty += Convert.ToString((byte)s[index], 2).PadLeft(8, '0').Substring(1);
                string str1 = empty.PadLeft((int)Math.Ceiling((Decimal)empty.Length / new Decimal(8)) * 8, '0');
                List<byte> byteList = new List<byte>();
                while (str1 != string.Empty)
                {
                    string str2 = str1.Substring(0, str1.Length > 7 ? 8 : str1.Length).PadRight(8, '0');
                    str1 = str1.Length > 7 ? str1.Substring(8) : string.Empty;
                    byteList.Add(Convert.ToByte(str2, 2));
                }
                byteList.Reverse();
                var messageBytes = byteList.ToArray();
                var encodedData = "";
                foreach (byte b in messageBytes)
                {
                    encodedData += Convert.ToString(b, 16).PadLeft(2, '0'); 
                }
                return encodedData.ToUpper();
            }
