    public static class DynazipCompressor
    {
        const int DZ_DEFLATE_POS = 46;
        
        public static bool IsDynazip(byte[] source)
        {
            return source.Length >= 4 && BitConverter.ToInt32(source, 0) == 0x02014b50;
        }
        
        public static byte[] DeCompress(byte[] source)
        {
            if (!IsDynazip(source))
                throw new InvalidDataException("not dynazip header");
            using (MemoryStream srcStream = new MemoryStream(source, DZ_DEFLATE_POS, source.Length - DZ_DEFLATE_POS))
            using (MemoryStream dstStream = DeCompress(srcStream))
                return dstStream.ToArray();
        }
        
        private static MemoryStream DeCompress(Stream source)
        {
            MemoryStream dest = new MemoryStream();
            DeCompress(source, dest);
            dest.Position = 0;
            return dest;
        }
        private static void DeCompress(Stream source, Stream dest)
        {
            using (DeflateStream zsSource = new DeflateStream(source, CompressionMode.Decompress, true))
            {
                zsSource.CopyTo(dest);
            }
        }
    }
