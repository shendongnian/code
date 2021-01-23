    // make a four byte array of the int
    byte[] parts = BitConverter.GetBytes(result);
    // put the bytes in the right order
    if (BitConverter.IsLittleEndian) {
      Array.Reverse(parts);
    }
    // turn the bytes into the xx-xx-xx-xx format
    string resultString = BitConverter.ToString(parts);
