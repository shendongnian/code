    static unsafe uint ChecksumInt(byte[] array)
    {
      unchecked
      {
        uint checksum = 0;
        fixed (byte* ptr = array)
        {
          var intPtr = (uint*)ptr;
          var iterations = array.Length / 4;
          var remainderIterations = array.Length % 4;
          for (var i = 0; i < iterations; i++)
          {
            var val = intPtr[i];
            checksum += val;
          }
          while (remainderIterations >= 0) // no more than 3 iterations
          {
            checksum += ptr[array.Length - remainderIterations];
            remainderIterations--;
          }
          return checksum;
        }
      }
    }
    static unsafe ulong ChecksumLong(byte[] array)
    {
      unchecked
      {
        ulong checksum = 0;
        fixed (byte* ptr = array)
        {
          var intPtr = (ulong*)ptr;
          var iterations = array.Length / 8;
          var remainderIterations = array.Length % 8;
          for (var i = 0; i < iterations; i++)
          {
            var val = intPtr[i];
            checksum += val;
          }
          while (remainderIterations >= 0) // no more than 7 iterations
          {
            checksum += ptr[array.Length - remainderIterations];
            remainderIterations--;
          }
          return checksum;
        }
      }
    }
