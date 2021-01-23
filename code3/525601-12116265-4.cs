    public class GZipStringComplexity : IStringComplexity
    {
        public double GetCompressionRatio(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] compressed;
            using (MemoryStream outStream = new MemoryStream())
            {
                using (var zipStream = new GZipStream(
                    outStream, CompressionMode.Compress))
                {
                    using (var memoryStream = new MemoryStream(inputBytes))
                    {
                        memoryStream.CopyTo(zipStream);
                    }
                }
                compressed = outStream.ToArray();
            }
            return (double)inputBytes.Length / compressed.Length;
        }
        /// <summary>
        /// Returns relevant complexity of a string on a scale [0..1], 
        /// where <value>0</value> has very low complexity
        /// and <value>1</value> has maximum complexity
        /// </summary>
        /// <param name="min">minimum compression ratio observed</param>
        /// <param name="max">maximum compression ratio observed</param>
        /// <param name="current">the value of compression ration
        /// for which complexity is being calculated</param>
        /// <returns>A relative complexity of a string</returns>
        public double GetRelevantComplexity(double min, double max, double current)
        {
            return 1 - current / (max - min);
        }
    }
