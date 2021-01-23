    byte[] bytes = new byte[]{ 0x42, 0xE6, 0x56, 0x00 }; // Big endian data
    if (BitConverter.IsLittleEndian) {
        Array.Reverse(bytes); // Convert big endian to little endian
    }
    float myFloat = BitConverter.ToSingle(bytes, 0);
