        /// <summary>
        /// Method to convert a string of hexadecimal character pairs
        /// to a byte array.
        /// </summary>
        /// <param name="hexValue">Hexadecimal character pair string.</param>
        /// <returns>A byte array </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when argument is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when argument contains an odd number of characters.</exception>
        /// <exception cref="System.FormatException">Thrown when argument contains non-hexadecimal characters.</exception>
        public static byte[] HexStringToByteArray(string hexValue)
        {
            ArgumentValidation.CheckNullReference(hexValue, "hexValue");
            if (hexValue.Length % 2 == 1)
                throw new ArgumentException("ERROR: String must have an even number of characters.", "hexValue");
            byte[] values = new byte[hexValue.Length / 2];
            for (int i = 0; i < values.Length; i++)
                values[i] = byte.Parse(hexValue.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            return values;
        }   // HexStringToByteArray()
        /// <summary>
        /// Method to convert a byte array to a hexadecimal string.
        /// </summary>
        /// <param name="values">Byte array.</param>
        /// <returns>A hexadecimal string.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when argument is null.</exception>
        public static string ByteArrayToHexString(byte[] values)
        {
            ArgumentValidation.CheckNullReference(values, "values");
            StringBuilder hexValue = new StringBuilder();
            foreach (byte value in values)
            {
                hexValue.Append(value.ToString("X2"));
            }
            return hexValue.ToString();
        }   // ByteArrayToHexString()
        public static byte[] GetStringToBytes(string value)
        {
            SoapHexBinary shb = SoapHexBinary.Parse(value);
            return shb.Value;
        }
        public static string GetBytesToString(byte[] value)
        {
            SoapHexBinary shb = new SoapHexBinary(value);
            return shb.ToString();
        } 
