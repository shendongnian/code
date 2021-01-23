    internal static class HashKeys
    {
        internal static readonly UInt64[,] PieceSquareKeys = new UInt64[64,16];
        internal static readonly UInt64[] EnPassantKeys = new UInt64[64];
        internal static readonly UInt64 SideToMoveKey;
        internal static readonly UInt64 WhiteCastlingKingSideKey;
        internal static readonly UInt64 WhiteCastlingQueenSideKey;
        internal static readonly UInt64 BlackCastlingKingSideKey;
        internal static readonly UInt64 BlackCastlingQueenSideKey;
        // Constructor - generates pseudo-random numbers for Zobrist hashing.
        // The use of a CSPRNG is a good guaranteee of genuinely random numbers.
        static HashKeys()
        {
            RNGCryptoServiceProvider randomGenerator = new RNGCryptoServiceProvider();
            byte[] eightRandomBytes = new byte[8];
            try
            {
                for (Int32 i1 = 0; i1 < 64; i1++)
                {
                    for (Int32 i2 = 0; i1 < 16; i1++)
                    {
                        randomGenerator.GetBytes(eightRandomBytes);
                        PieceSquareKeys[i1, i2] = BitConverter.ToUInt64(eightRandomBytes, 0);
                    }
                    randomGenerator.GetBytes(eightRandomBytes);
                    EnPassantKeys[i1] = BitConverter.ToUInt64(eightRandomBytes, 0);
                }
                randomGenerator.GetBytes(eightRandomBytes);
                SideToMoveKey = BitConverter.ToUInt64(eightRandomBytes, 0);
                randomGenerator.GetBytes(eightRandomBytes);
                WhiteCastlingKingSideKey = BitConverter.ToUInt64(eightRandomBytes, 0);
                randomGenerator.GetBytes(eightRandomBytes);
                WhiteCastlingQueenSideKey = BitConverter.ToUInt64(eightRandomBytes, 0);
                randomGenerator.GetBytes(eightRandomBytes);
                BlackCastlingKingSideKey = BitConverter.ToUInt64(eightRandomBytes, 0);
                randomGenerator.GetBytes(eightRandomBytes);
                BlackCastlingQueenSideKey = BitConverter.ToUInt64(eightRandomBytes, 0);
            }
            finally
            {
                randomGenerator.Dispose();
            }
        }
    }
