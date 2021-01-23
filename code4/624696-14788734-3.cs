        [Test]
        public void ReadFromBinaryFile()
        {
            // Approach one
            using (var filestream = File.Open(@"C:\apps\test.bin", FileMode.Open))
            using (var binaryStream = new BinaryReader(filestream))
            {
                var pos = 0;
                var length = (int)binaryStream.BaseStream.Length;
                while (pos < length)
                {
                    var integerFromFile = binaryStream.ReadInt32();
                    pos += sizeof(int);
                }
            }
        }
