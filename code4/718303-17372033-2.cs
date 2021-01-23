       static void Main(string[] args)
        {
            var binaryWrite = new BinaryWriter(new MemoryStream(new byte[] {1, 2, 3, 4}));
            binaryWrite.Seek(3, SeekOrigin.Begin);
            var position = binaryWrite.BaseStream.Position;
            new MemoryStream(new byte[] {1, 2, 3, 4}).CopyTo(binaryWrite.BaseStream);
            position = binaryWrite.BaseStream.Position;
        }
