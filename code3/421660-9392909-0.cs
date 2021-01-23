        /// <summary>
        /// The base number for binary values
        /// </summary>
        private const int BinaryBaseNumber = 2;
        /// <summary>
        /// The number of binary digits used to represent the binary number for a double precision floating
        /// point value. i.e. there are this many digits used to represent the
        /// actual number, where in a number as: 0.134556 * 10^5 the digits are 0.134556 and the exponent is 5.
        /// </summary>
        private const int DoublePrecision = 53;
        private static readonly double doubleMachinePrecision = Math.Pow(BinaryBaseNumber, -DoublePrecision);
