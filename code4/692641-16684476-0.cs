    public byte[,] Encrypt(byte[,] dataToEncrypt, byte[] givenKey, byte[] initializationVector)
        {
            //Setup
            ECB encryptor = new ECB();
            byte[,] cypherText = new byte[4,4];
            //XOR the data with the IV
            for (int row = 0; row < 4; row++)
            {
                cypherText[row, 0] = (byte)(dataToEncrypt[row, 0] ^ initializationVector[4 * row]);
                cypherText[row, 1] = (byte)(dataToEncrypt[row, 1] ^ initializationVector[(4 * row) + 1]);
                cypherText[row, 2] = (byte)(dataToEncrypt[row, 2] ^ initializationVector[(4 * row) + 2]);
                cypherText[row, 3] = (byte)(dataToEncrypt[row, 3] ^ initializationVector[(4 * row) + 3]);
            }
            return encryptor.Encrypt(cypherText, givenKey);
        }
