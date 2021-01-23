        /// <summary>
        /// Unzips (inflates) zipped data.
        /// </summary>
        /// <param name="zippedData">The zipped data.</param>
        /// <returns>The inflated data.</returns>
        public Byte[] GUnzip(Byte[] zippedData)
        {
            using (MemoryStream unzippedData = new MemoryStream())
            {
                using (GZipInputStream zippedDataStream = new GZipInputStream(new MemoryStream(zippedData)))
                {
                    CopyStream(zippedDataStream, unzippedData);
                }
                return unzippedData.ToArray();
            }
        }
        /// <summary>
        /// zips data.
        /// </summary>
        /// <param name="unzippedData">The unzipped data.</param>
        /// <returns>The zipped data.</returns>
        public Byte[] GZip(Byte[] unzippedData)
        {
            using (MemoryStream zippedData = new MemoryStream())
            {
                using (GZipOutputStream unzippedDataStream = new GZipOutputStream(new MemoryStream(unzippedData)))
                {
                    CopyStream(unzippedDataStream, zippedData);
                }
                return zippedData.ToArray();
            }
        }
        /// <summary>
        /// Accepts an inStream, writes it to a buffer and goes out the outStream
        /// </summary>
        /// <param name="inStream">The input Stream</param>
        /// <param name="outStream">The output Stream</param>
        private static void CopyStream(Stream inStream, Stream outStream)
        {
            int nRead = 0;
            // Using a 2k buffer
            Byte[] theBuffer = new Byte[2048];
            while ((nRead = inStream.Read(theBuffer, 0, theBuffer.Length)) > 0)
            {
                outStream.Write(theBuffer, 0, nRead);
            }
        }
