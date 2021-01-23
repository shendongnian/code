using System.IO;
namespace RTime
{
    public class RTimeCompressor
    {
        /// <summary>
        /// Compress data in the supplied stream
        /// </summary>
        /// <param name="inputData">Data to be compressed</param>
        /// <param name="compressedBytes">Number of compressed bytes. Normally value is equal to inputData.Length unless maxAcceptableCompressionSize is reached.</param>
        /// <param name="maxAcceptableCompressionSize">Upper limit of the length of the returned compressed memory stream</param>
        /// <returns>Compressed data stream</returns>
        public static MemoryStream Compress(Stream inputData, out int compressedBytes, int maxAcceptableCompressionSize = (int)short.MaxValue)
        {
            int[] positions = new int[256];
            int pos = 0;
            MemoryStream compressed = new MemoryStream();
            inputData.Seek(0, SeekOrigin.Begin);
            while (pos < inputData.Length &&
                    compressed.Position <= maxAcceptableCompressionSize - 2)
            {
                int runlen = 0;
                byte value = GetByteAtPos(inputData, pos++);
                int backpos = positions[value];
                compressed.WriteByte(value);
                positions[value] = pos;
                while ((backpos < pos) &&
                        (pos < inputData.Length) &&
                        (GetByteAtPos(inputData, pos) == GetByteAtPos(inputData, backpos)) &&
                        (runlen < 255))
                {
                    backpos++;
                    pos++;
                    runlen++;
                }
                compressed.WriteByte((byte)runlen);
            }
            // result is larger than the original input
            if (compressed.Position >= pos)
            {
                compressedBytes = 0;
                return null;
            }
            compressed.Seek(0, SeekOrigin.Begin);
            compressedBytes = pos;
            return compressed;
        }
        private static byte GetByteAtPos(Stream inputData, int pos)
        {
            long originalPos = inputData.Position;
            inputData.Seek(pos, SeekOrigin.Begin);
            byte value = (byte)inputData.ReadByte();
            inputData.Seek(originalPos, SeekOrigin.Begin);
            return value;
        }
        /// <summary>
        /// Decompress data in the supplied stream
        /// </summary>
        /// <param name="inputData">Data to be decompressed</param>
        /// <returns>Decompressed data stream</returns>
        public static MemoryStream Decompress(Stream inputData)
        {
            int[] positions = new int[256];
            int pos = 0;
            MemoryStream decompressed = new MemoryStream();
            inputData.Seek(0, SeekOrigin.Begin);
            while (pos < inputData.Length)
            {
                byte value = GetByteAtPos(inputData, pos++);
                int backoffs = positions[value];
                int repeat = GetByteAtPos(inputData, pos++);
                decompressed.WriteByte(value);
                positions[value] = (int)decompressed.Position;
                if (repeat > 0)
                {
                    for (int i = 0; i < repeat; i++)
                    {
                        decompressed.WriteByte(GetByteAtPos(decompressed, backoffs++));
                    }
                }
            }
            decompressed.Seek(0, SeekOrigin.Begin);
            return decompressed;
        }
    }
}
