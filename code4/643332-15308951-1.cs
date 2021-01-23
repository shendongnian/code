        const int Id1 = 0x1F;
        const int Id2 = 0x8B;
        const int DeflateCompression = 0x8;
        const int GzipFooterLength = 8;
        const int MaxGzipFlag = 32; 
        /// <summary>
        /// Returns true if the stream could be a valid gzip header at the current position.
        /// </summary>
        /// <param name="stream">The stream to check.</param>
        /// <returns>Returns true if the stream could be a valid gzip header at the current position.</returns>
        public static bool IsHeaderCandidate(Stream stream)
        {
            // Read the first ten bytes of the stream
            byte[] header = new byte[10];
            int bytesRead = stream.Read(header, 0, header.Length);
            stream.Seek(-bytesRead, SeekOrigin.Current);
            if (bytesRead < header.Length)
            {
                return false;
            }
            // Check the id tokens and compression algorithm
            if (header[0] != Id1 || header[1] != Id2 || header[2] != DeflateCompression)
            {
                return false;
            }
            // Extract the GZIP flags, of which only 5 are allowed (2 pow. 5 = 32)
            if (header[3] > MaxGzipFlag)
            {
                return false;
            }
            // Check the extra compression flags, which is either 2 or 4 with the Deflate algorithm
            if (header[8] != 0x0 && header[8] != 0x2 && header[8] != 0x4)
            {
                return false;
            }
            return true;
        }
