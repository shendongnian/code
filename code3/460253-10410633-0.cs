    public static byte[] ToNetwork(int value) {
      byte[] data = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian) {
        Array.Reverse(data);
      }
      return data;
    }
