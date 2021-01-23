    public static class StreamEOF {
        public static bool EOF( this BinaryReader binaryReader ) {
            var bs = binaryReader.BaseStream;
            return ( bs.Position == bs.Length);
        }
    }
