    public static class EncodingEx
    {
        /// <summary>
        /// Convert a C char* to <see cref="string"/>.
        /// </summary>
        /// <param name="encoding">C char* encoding.</param>
        /// <param name="cString">C char* to convert.</param>
        /// <returns>The converted <see cref="string"/>.</returns>
        public static string ReadCString(this Encoding encoding, byte[] cString)
        {
            var nullIndex = Array.IndexOf(cString, (byte) 0);
            nullIndex = (nullIndex == -1) ? cString.Length : nullIndex;
            return encoding.GetString(cString, 0, nullIndex);
        }
    }
    ...
    // A call
    Encoding.ASCII.ReadCString(buffer)
