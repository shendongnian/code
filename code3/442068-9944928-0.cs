    public class RiffDescriptor
    {
        public RiffDescriptor(BinaryReader b)
        {
            // Read the ChunkID - Should be RIFF
            ChunkID = b.ReadBytes(4);
            
            // Read the ChunkSize
            ChunkSize = b.ReadUInt32();
            
            // Read the Format - Should be WAVE
            Format = b.ReadBytes(4);
        }
        [DebuggerDisplay("ChunkID = {System.Text.Encoding.Default.GetString(ChunkID)}")]
        public byte[] ChunkID;
        public UInt32 ChunkSize;
        [DebuggerDisplay("Format = {System.Text.Encoding.Default.GetString(Format)}")]
        public byte[] Format;
    }
