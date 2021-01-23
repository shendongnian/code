    double ulpc(double value) {
      long long bits = BitConverter::DoubleToInt64Bits(value);
      if ((bits & 0x7FF0000000000000L) == 0x7FF0000000000000L) { // if x is not finite
        if (bits & 0x000FFFFFFFFFFFFFL) { // if x is a NaN
          return value;  // I did not force the sign bit here with NaNs.
          } 
        return BitConverter.Int64BitsToDouble(0x7FF0000000000000L); // Positive Infinity;
        }
      bits &= 0x7FFFFFFFFFFFFFFFL; // make positive
      if (bits == 0x7FEFFFFFFFFFFFFFL) { // if x == max_double (notice the _E_)
        return BitConverter.Int64BitsToDouble(bits) - BitConverter.Int64BitsToDouble(bits-1);
      }
      double nextValue = BitConverter.Int64BitsToDouble(bits + 1);
      double result = nextValue - fabs(value);
    }
