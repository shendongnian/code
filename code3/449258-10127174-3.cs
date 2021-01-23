    bool remoteSystemIsLittleEndian = false;
    ushort stringLength = 511;
    byte[] stringLengthBytes = BitConverter.GetBytes(stringLength);
    if (BitConverter.IsLittleEndian != remoteSystemIsLittleEndian)
    {
        Array.Reverse(stringLengthBytes);
    }
