    static byte[] AESCounter(byte[] key, ulong counter) {
        byte[] InputBlock = new byte[16];
        InputBlock[0] = (byte)(counter & 0xffL);
        InputBlock[1] = (byte)((counter & 0xff00L) >> 8);
        InputBlock[2] = (byte)((counter & 0xff0000L) >> 16);
        InputBlock[3] = (byte)((counter & 0xff000000L) >> 24);
        InputBlock[4] = (byte)((counter & 0xff00000000L) >> 32);
        InputBlock[5] = (byte)((counter & 0xff0000000000L) >> 40);
        InputBlock[6] = (byte)((counter & 0xff000000000000L) >> 48);
        InputBlock[7] = (byte)((counter & 0xff00000000000000L) >> 54);
        using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
        {
            AES.Key = key;
            AES.Mode = CipherMode.ECB;
            AES.Padding = PaddingMode.None;
            using (ICryptoTransform Encryptor = AES.CreateEncryptor())
            {
                return Encryptor.TransformFinalBlock(InputBlock, 0, 16);
            }
        }
    }
