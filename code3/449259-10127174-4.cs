    bool remoteSystemIsLittleEndian = false;
    byte[] stringLengthBytes = new byte[] { 1, 255 };
    if (BitConverter.IsLittleEndian != remoteSystemIsLittleEndian)
    {
        Array.Reverse(stringLengthBytes);
    }
    int stringLength = (int)BitConverter.ToUInt16(stringLengthBytes, 0);
