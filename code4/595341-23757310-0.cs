        public static Byte[] Encrypt(Byte[] input, SymmetricAlgorithm crypto)
        {
            return Transform(crypto.CreateEncryptor(), input, crypto.BlockSize);
        }
        public static Byte[] Decrypt(Byte[] input, SymmetricAlgorithm crypto)
        {
            return Transform(crypto.CreateDecryptor(), input, crypto.BlockSize);
        }
        private static Byte[] Transform(ICryptoTransform cryptoTransform, Byte[] input, Int32 blockSize)
        {
            if (input.Length > blockSize)
            {
                Byte[] ret1 = new Byte[( ( input.Length - 1 ) / blockSize ) * blockSize];
                Int32 inputPos = 0;
                Int32 ret1Length = 0;
                for (inputPos = 0; inputPos < input.Length - blockSize; inputPos += blockSize)
                {
                    ret1Length += cryptoTransform.TransformBlock(input, inputPos, blockSize, ret1, ret1Length);
                }
                Byte[] ret2 = cryptoTransform.TransformFinalBlock(input, inputPos, input.Length - inputPos);
                Byte[] ret = new Byte[ret1Length + ret2.Length];
                Array.Copy(ret1, 0, ret, 0, ret1Length);
                Array.Copy(ret2, 0, ret, ret1Length, ret2.Length);
                return ret;
            }
            else
            {
                return cryptoTransform.TransformFinalBlock(input, 0, input.Length); 
            }
        }
