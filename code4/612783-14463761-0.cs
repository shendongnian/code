    int value;
    byte[] bytes = BitConverter.GetBytes(value);
    if (BitConverter.IsLittleEndian){
    Array.Reverse(bytes);
    }
    byte[] result = bytes;
