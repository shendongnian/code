    using (BinaryWriter bw = new BinaryWriter(writer))
    {
        foreach (var item in RIFFChunks)
        {
            if (!(bw.BaseStream.Position % 2 == 0))
            {
                bw.Write((byte)0);
            }
            bw.Write(Encoding.Default.GetBytes(item.Key));
            bw.Write(item.Value.Length + 1);
            bw.Write(Encoding.Default.GetBytes(item.Value));
            bw.Write((byte)0);
        }
    }
