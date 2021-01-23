    using System;
    using System.Text;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Crypto.Modes;
    using Org.BouncyCastle.Crypto.Parameters;
    public class AES
    {
        private readonly Encoding encoding;
        private SicBlockCipher mode;
        public AES(Encoding encoding)
        {
            this.encoding = encoding;
            this.mode = new SicBlockCipher(new AesFastEngine());
        }
        public static string ByteArrayToString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
        public static byte[] StringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
        public string Encrypt(string plain, byte[] key, byte[] iv)
        {
            byte[] input = this.encoding.GetBytes(plain);
            byte[] bytes = this.BouncyCastleCrypto(true, input, key, iv);
            string result = ByteArrayToString(bytes);
            return result;
        }
        public string Decrypt(string cipher, byte[] key, byte[] iv)
        {
            byte[] bytes = this.BouncyCastleCrypto(false, StringToByteArray(cipher), key, iv);
            string result = this.encoding.GetString(bytes);
            return result;
        }
        private byte[] BouncyCastleCrypto(bool forEncrypt, byte[] input, byte[] key, byte[] iv)
        {
            try
            {
                this.mode.Init(forEncrypt, new ParametersWithIV(new KeyParameter(key), iv));
                BufferedBlockCipher cipher = new BufferedBlockCipher(this.mode);
                return cipher.DoFinal(input);
            }
            catch (CryptoException)
            {
                throw;
            }
        }
    }
