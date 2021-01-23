    private string IntToBytes(int count)
    { 
    // make a four byte array of the int
    byte[] parts = BitConverter.GetBytes(count);
    // put the bytes in the right order
    if (BitConverter.IsLittleEndian) {
      Array.Reverse(parts);
    }
    // turn the bytes into the xx-xx-xx-xx format
    return BitConverter.ToString(parts);
    }
