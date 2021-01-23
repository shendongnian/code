    public static string ByteToString(byte[] buff)
        {
            string sbinary = "";
    
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
