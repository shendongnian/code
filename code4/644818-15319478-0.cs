    byte[] bytes = BitConverter.GetBytes(0x42E65600);
    if (!BitConverter.IsLittleEndian) {
        bytes = bytes.Reverse().ToArray();
    }
    float myFloat = BitConverter.ToSingle(bytes, 0);
