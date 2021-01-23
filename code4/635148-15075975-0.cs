    class Program
    {
        private static byte[] HexToByte(string hex)
        {
            byte[] r = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length - 1; i += 2)
            {
                byte a = GetHex(hex[i]);
                byte b = GetHex(hex[i + 1]);
                r[i / 2] = (byte)(a * 16 + b);
            }
            return r;
        }
        private static byte GetHex(char x)
        {
            if (x <= '9' && x >= '0')
            {
                return (byte)(x - '0');
            }
            else if (x <= 'z' && x >= 'a')
            {
                return (byte)(x - 'a' + 10);
            }
            else if (x <= 'Z' && x >= 'A')
            {
                return (byte)(x - 'A' + 10);
            }
            return 0;
        }
        static void Main(string[] args)
        {
            BlowFish b = new BlowFish("12345678abcdefgmypassword");
            string plainText = "ABCDEFG12345678";
            string cipherText = b.Encrypt_CBC(plainText);
            MessageBox.Show(cipherText);
            plainText = b.Decrypt_CBC(cipherText);
            byte[] myByteArray = HexToByte(cipherText);
            MessageBox.Show(plainText);
        }
    }
