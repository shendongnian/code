    bool remoteSystemIsLittleEndian = false;
    int stringLength = 511;
    byte[] stringLengthBytes = BitConverter.GetBytes((ushort)stringLength);
    if (BitConverter.IsLittleEndian != remoteSystemIsLittleEndian)
    {
        Array.Reverse(stringLengthBytes);
    }
