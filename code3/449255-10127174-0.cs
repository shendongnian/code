    bool remoteSystemIsLittleEndian = false;
    byte[] stringLengthBytes = new byte[] { 1, 255 };
    if (BitConverter.IsLittleEndian != remoteSystemIsLittleEndian)
    {
        Array.Reverse(stringLengthBytes);
    }
    ushort stringLength = BitConverter.ToUInt16(stringLengthBytes, 0);
