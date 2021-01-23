    public static class StreamExtensions
    {
        /// <summary>
        /// Inserts the specified binary data at the current position in the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="array">The array.</param>
        /// <remarks>
        /// <para>Note that this is a very expensive operation, as all the data following the insertion point has to
        /// be moved.</para>
        /// <para>When this method returns, the writer will be positioned at the end of the inserted data.</para>
        /// </remarks>
        public static void Insert(this Stream stream, byte[] array)
        {
            #region Contract
            if (stream == null)
                throw new ArgumentNullException("writer");
            if (array == null)
                throw new ArgumentNullException("array");
            if (!stream.CanRead || !stream.CanWrite || !stream.CanSeek)
                throw new ArgumentException("writer");
            #endregion
            long originalPosition = stream.Position;
            long readingPosition = originalPosition;
            long writingPosition = originalPosition;
            int length = array.Length;
            int bufferSize = 4096;
            while (bufferSize < length)
                bufferSize *= 2;
            int currentBuffer = 1;
            int[] bufferContents = new int[2];
            byte[][] buffers = new [] { new byte[bufferSize], new byte[bufferSize] };
            Array.Copy(array, buffers[1 - currentBuffer], array.Length);
            bufferContents[1 - currentBuffer] = array.Length;
            bool done;
            do
            {
                bufferContents[currentBuffer] = ReadBlock(stream, ref readingPosition, buffers[currentBuffer], out done);
                // Switch buffers.
                currentBuffer = 1 - currentBuffer;
                WriteBlock(stream, ref writingPosition, buffers[currentBuffer], bufferContents[currentBuffer]);
            } while (!done);
            // Switch buffers.
            currentBuffer = 1 - currentBuffer;
            // Write the remaining data.
            WriteBlock(stream, ref writingPosition, buffers[currentBuffer], bufferContents[currentBuffer]);
            stream.Position = originalPosition + length;
        }
        private static void WriteBlock(Stream stream, ref long writingPosition, byte[] buffer, int length)
        {
            stream.Position = writingPosition;
            stream.Write(buffer, 0, length);
            writingPosition += length;
        }
        private static int ReadBlock(Stream stream, ref long readingPosition, byte[] buffer, out bool done)
        {
            stream.Position = readingPosition;
            int bufferContent = 0;
            int read;
            do
            {
                read = stream.Read(buffer, bufferContent, buffer.Length - bufferContent);
                bufferContent += read;
                readingPosition += read;
            } while (read > 0 && read < buffer.Length);
            done = read == 0;
            return bufferContent;
        }
    }
