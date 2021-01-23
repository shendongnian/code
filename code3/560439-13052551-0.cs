    if (BitConverter.IsLittleEndian) {
      byte[] parts = BitConverter.GetBytes(mask);
      Array.Reverse(parts);
      mask = BitConverter.ToInt32(parts, 0);
    }
