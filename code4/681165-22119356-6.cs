    /// <summary>
    /// More generic version of the built-in Rfc2898DeriveBytes class. This one
    /// allows an arbitrary Pseudo Random Function, meaning we can use e.g. 
    /// HMAC SHA256 or HMAC SHA512 rather than the hardcoded HMAC SHA-1 of the 
    /// built-in version.
    /// </summary>
    public class PBKDF2DeriveBytes : DeriveBytes
    {
        // Initialization:
        
        private readonly IPseudoRandomFunction prf;
        private readonly byte[] salt;
        private readonly long iterationCount;
        private readonly byte[] saltAndBlockNumber;
        // State:
        
        // Last result of prf.Transform - also used as buffer
        // between GetBytes() calls:
        private byte[] buffer;
        
        private int bufferIndex;
        private int nextBlock;
        /// <param name="prf">
        ///    The Pseudo Random Function to use for calculating the derived key
        /// </param>
        /// <param name="salt">
        ///    The initial salt to use in calculating the derived key
        /// </param>
        /// <param name="iterationCount">
        ///    Number of iterations. RFC 2898 recommends a minimum of 1000
        ///    iterations (in the year 2000) ideally with number of iterations
        ///    adjusted on a regular basis (e.g. each year).
        /// </param>
        public PBKDF2DeriveBytes(
           IPseudoRandomFunction prf, byte[] salt, long iterationCount)
        {
            if (prf == null)
            {
                throw new ArgumentNullException("prf");
            }
            if (salt == null)
            {
                throw new ArgumentNullException("salt");
            }
            this.prf = prf;
            this.salt = salt;
            this.iterationCount = iterationCount;
            // Prepare combined salt = concat(original salt, block number)
            saltAndBlockNumber = new byte[salt.Length + 4];
            Buffer.BlockCopy(salt, 0, saltAndBlockNumber, 0, salt.Length);
            Reset();
        }
        /// <summary>
        ///    Retrieves a derived key of the length specified.
        ///    Successive calls to GetBytes will return different results -
        ///    calling GetBytes(20) twice is equivalent to calling
        ///    GetBytes(40) once. Use Reset method to clear state.
        /// </summary>
        /// <param name="keyLength">
        ///    The number of bytes required. Note that for password hashing, a
        ///    key length greater than the output length of the underlying Pseudo
        ///    Random Function is redundant and does not increase security.
        /// </param>
        /// <returns>The derived key</returns>
        public override byte[] GetBytes(int keyLength)
        {
            var result = new byte[keyLength];
            int resultIndex = 0;
            // If we have bytes in buffer from previous run, use those first:
            if (buffer != null && bufferIndex > 0)
            {
                int bufferRemaining = prf.HashSize - bufferIndex;
                
                // Take at most keyLength bytes from the buffer:
                int bytesFromBuffer = Math.Min(bufferRemaining, keyLength);
                
                if (bytesFromBuffer > 0)
                {
                    Buffer.BlockCopy(buffer, bufferIndex, result, 0,
                       bytesFromBuffer);
                    bufferIndex += bytesFromBuffer;
                    resultIndex += bytesFromBuffer;
                }
            }
            // If, after filling from buffer, we need more bytes to fill
            // the result, they need to be computed:
            if (resultIndex < keyLength)
            {
                ComputeBlocks(result, resultIndex);
                // If we used the entire buffer, reset index:
                if (bufferIndex == prf.HashSize)
                {
                    bufferIndex = 0;
                }
            }
            return result;
        }
        /// <summary>
        ///    Resets state. The next call to GetBytes will return the same
        ///    result as an initial call to GetBytes.
        ///    Sealed since it's called from constructor.
        /// </summary>
        public sealed override void Reset()
        {
            buffer = null;
            bufferIndex = 0;
            nextBlock = 1;
        }
        private void ComputeBlocks(byte[] result, int resultIndex)
        {
            int currentBlock = nextBlock;
            // Keep computing blocks until we've filled the result array:
            while (resultIndex < result.Length)
            {
                // Run iterations for block:
                F(currentBlock);
                // Populate result array with the block, but only as many bytes
                // as are needed - keep the rest in buffer:
                int bytesFromBuffer = Math.Min(
                       prf.HashSize,
                       result.Length - resultIndex
                );
                Buffer.BlockCopy(buffer, 0, result, resultIndex, bytesFromBuffer);
                bufferIndex = bytesFromBuffer;
                resultIndex += bytesFromBuffer;
                currentBlock++;
            }
            nextBlock = currentBlock;
        }
        private void F(int currentBlock)
        {
            // First iteration:
            // Populate initial salt with the current block index:
            Buffer.BlockCopy(
               BlockNumberToBytes(currentBlock), 0, 
               saltAndBlockNumber, salt.Length, 4
            );
            
            buffer = prf.Transform(saltAndBlockNumber);
            // Remaining iterations:
            byte[] result = buffer;
            for (long iteration = 2; iteration <= iterationCount; iteration++)
            {
                // Note that the PRF transform takes the immediate result of the
                // last iteration, not the combined result (in buffer):
                result = prf.Transform(result);
                for (int byteIndex = 0; byteIndex < buffer.Length; byteIndex++)
                {
                    buffer[byteIndex] ^= result[byteIndex];
                }
            }
        }
        private static byte[] BlockNumberToBytes(int blockNumber)
        {
            byte[] result = BitConverter.GetBytes(blockNumber);
            
            // Make sure the result is big endian:
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(result);
            }
            return result;
        }
    }
