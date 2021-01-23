    static void Main(string[] args)
        {
            string strInputString = "test";
            string strKeyString = "test123";
            string myIV = GetMacAddress();
            string encryptedString = Encrypt(strInputString, strKeyString, myIV);
            string decryptedString = Decrypt(encryptedString, strKeyString, myIV);
        }
        public static string Decrypt(string strInputString, string strKeyString, string myIV)
        {
            if ((strInputString == null) || (strInputString.Length == 0))
            {
                return strInputString;
            }
            
                int num5;
                int keySize = 0x100;
                int blockSize = 0x100;
                int length = keySize / 0x10;
                if (strKeyString.Length > length)
                {
                    strKeyString = strKeyString.Substring(0, length);
                }
                if (strKeyString.Length < length)
                {
                    strKeyString = strKeyString.PadRight(length, '#');
                }
                Encoding.Unicode.GetBytes(strKeyString);
                if (myIV.Length > length)
                {
                    myIV = myIV.Substring(0, length);
                }
                if (myIV.Length < length)
                {
                    myIV = myIV.PadRight(length, '#');
                }
                Encoding.Unicode.GetBytes(myIV);
                byte[] bytes = Encoding.Unicode.GetBytes(strKeyString);
                byte[] rgbIV = Encoding.Unicode.GetBytes(myIV);
                RijndaelManaged managed = new RijndaelManaged
                {
                    BlockSize = blockSize,
                    KeySize = keySize
                };
                MemoryStream stream = new MemoryStream();
                for (int i = 0; i < strInputString.Length; i += 2)
                {
                    stream.WriteByte(byte.Parse(strInputString.Substring(i, 2), NumberStyles.AllowHexSpecifier));
                }
                stream.Position = 0L;
                MemoryStream stream2 = new MemoryStream();
                CryptoStream stream3 = new CryptoStream(stream, managed.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Read);
                while ((num5 = stream3.ReadByte()) != -1)
                {
                    stream2.WriteByte((byte)num5);
                }
                stream3.Close();
                stream2.Close();
                stream.Close();
                byte[] buffer3 = stream2.ToArray();
                return Encoding.Unicode.GetString(buffer3);
        }
        public static string Encrypt(string strInputString, string strKeyString, string myIV)
        {
            if ((strInputString == null) || (strInputString.Length == 0))
            {
                return strInputString;
            }           
                int num4;
                int keySize = 0x100;
                int blockSize = 0x100;
                int length = keySize / 0x10;
                if (strKeyString.Length > length)
                {
                    strKeyString = strKeyString.Substring(0, length);
                }
                if (strKeyString.Length < length)
                {
                    strKeyString = strKeyString.PadRight(length, '#');
                }
                Encoding.Unicode.GetBytes(strKeyString);
                if (myIV.Length > length)
                {
                    myIV = myIV.Substring(0, length);
                }
                if (myIV.Length < length)
                {
                    myIV = myIV.PadRight(length, '#');
                }
                Encoding.Unicode.GetBytes(myIV);
                byte[] bytes = Encoding.Unicode.GetBytes(strKeyString);
                byte[] rgbIV = Encoding.Unicode.GetBytes(myIV);
                string str = "";
                RijndaelManaged managed = new RijndaelManaged
                {
                    BlockSize = blockSize,
                    KeySize = keySize
                };
                MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(strInputString));
                MemoryStream stream2 = new MemoryStream();
                CryptoStream stream3 = new CryptoStream(stream2, managed.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
                while ((num4 = stream.ReadByte()) != -1)
                {
                    stream3.WriteByte((byte)num4);
                }
                stream3.Close();
                stream2.Close();
                stream.Close();
                foreach (byte num5 in stream2.ToArray())
                {
                    str = str + num5.ToString("X2");
                }
                return str;
           
        }
        private static string GetMacAddress()
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
