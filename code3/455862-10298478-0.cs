    int ReadNext3Bytes(System.IO.BinaryReader reader) {
        try {
            byte b0 = reader.ReadByte();
            byte b1 = reader.ReadByte();
            byte b2 = reader.ReadByte();
            return MakeInt(b0, b1, b2);
        }
        catch { return 0; }
    }
    int MakeInt(byte b0, byte b1, byte b2) {
        return ((b0 << 0x10) | (b1 << 0x08)) | b2;
    }
