    /// <summary>
    /// Extension methods to convert <see cref="System.Numerics.BigInteger"/>
    /// instances to hexadecimal, octal, and binary strings.
    /// </summary>
    public static class BigIntegerExtensions
    {
      /// <summary>
      /// Converts a <see cref="BigInteger"/> to a binary string.
      /// </summary>
      /// <param name="bigint">A <see cref="BigInteger"/>.</param>
      /// <returns>
      /// A <see cref="System.String"/> containing a binary
      /// representation of the supplied <see cref="BigInteger"/>.
      /// </returns>
      public static string ToBinaryString(this BigInteger bigint)
      {
        var bytes = bigint.ToByteArray();
        var idx = GetMsbPtr(bytes);
        // Convert first byte without adding leading zeros.
        var base2 = new StringBuilder(
          Convert.ToString(bytes[idx], 2),
          (idx + 1) * 8);
        // Convert remaining bytes adding leading zeros.
        for (idx--; idx >= 0; idx--)
        {
          base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
        }
        return base2.ToString();
      }
      /// <summary>
      /// Converts a <see cref="BigInteger"/> to a hexadecimal string.
      /// </summary>
      /// <param name="bigint">A <see cref="BigInteger"/>.</param>
      /// <returns>
      /// A <see cref="System.String"/> containing a hexadecimal
      /// representation of the supplied <see cref="BigInteger"/>.
      /// </returns>
      public static string ToHexadecimalString(this BigInteger bigint)
      {
        var bytes = bigint.ToByteArray();
        var idx = GetMsbPtr(bytes);
        // Convert first byte without adding leading zeros.
        var base16 = new StringBuilder(
          Convert.ToString(bytes[idx], 16),
          (idx + 1) * 2);
        // Convert remaining bytes adding leading zeros.
        for (idx--; idx >= 0; idx--)
        {
          base16.Append(Convert.ToString(bytes[idx], 16).PadLeft(2, '0'));
        }
        return base16.ToString();
      }
      /// <summary>
      /// Converts a <see cref="BigInteger"/> to a octal string.
      /// </summary>
      /// <param name="bigint">A <see cref="BigInteger"/>.</param>
      /// <returns>
      /// A <see cref="System.String"/> containing an octal
      /// representation of the supplied <see cref="BigInteger"/>.
      /// </returns>
      public static string ToOctalString(this BigInteger bigint)
      {
        var bytes = bigint.ToByteArray();
        var idx = bytes.Length - 1;
        // Calculate how many bytes are extra when byte array is split
        // into three-byte (24-bit) chunks.
        var extra = bytes.Length % 3;
        // If no bytes are extra, use three bytes for first chunk.
        if (extra == 0)
        {
          extra = 3;
        }
        // Convert first chunk (24-bits) to integer value.
        int int24 = 0;
        for (; extra != 0; extra--)
        {
          int24 <<= 8;
          int24 += bytes[idx--];
        }
        // Convert 24-bit integer to octal without adding leading zeros.
        var base8 = new StringBuilder(
          Convert.ToString(int24, 8),
          ((bytes.Length / 3) + 1) * 8);
        // Convert remaining 24-bit chunks, adding leading zeros.
        for (; idx >= 0; idx -= 3)
        {
          int24 = (bytes[idx] << 16) + (bytes[idx - 1] << 8) + bytes[idx - 2];
          base8.Append(Convert.ToString(int24, 8).PadLeft(8, '0'));
        }
        return base8.ToString();
      }
      /// <summary>
      /// Returns a pointer to the most significant byte (MSB) in a
      /// <see cref="BigInteger"/> byte array that is not a leading zero.
      /// </summary>
      /// <param name="byteArray">
      /// A byte array created by the BigInteger.ToByteArray() method.
      /// </param>
      /// <returns>
      /// A <see cref="System.Int32"/> that points to the MSB in the array.
      /// </returns>
      private static int GetMsbPtr(byte[] byteArray)
      {
        var ptr = byteArray.Length - 1; // Most significant byte
        // If MSB has leading zero, then skip.
        if (ptr != 0 && byteArray[ptr] == 0)
        {
          ptr--;
        }
        return ptr;
      }
    }
