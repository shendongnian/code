    public struct EAN2AN_TYPE
    {
        public long ean; // can hold 5 bytes
        public int rec_no; // can hold 3 bytes
    }
    ...
    byte[] incoming = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
    using(var stream = new MemoryStream(incoming))
    using (var reader = new BinaryReader(stream))
    {
        // I leave it to you to get to the data
        stream.Seek(0, SeekOrigin.Begin);
        // get the data, padded to where we need for endianness
        var ean_bytes = new byte[8];
        // if this is wrong - then change param 4 to '3' to align at the other end
        Buffer.BlockCopy(reader.ReadBytes(5), 0, ean_bytes, 0, 5);
        var rec_no_bytes = new byte[4];
        // if this is wrong - then change param 4 to '1' to align at the other end
        Buffer.BlockCopy(reader.ReadBytes(3), 0, rec_no_bytes, 0, 3);
        var ean2 = new EAN2AN_TYPE();
        // convert
        ean2.ean = BitConverter.ToInt64(ean_bytes, 0);
        ean2.rec_no = BitConverter.ToInt32(rec_no_bytes, 0);
    }
