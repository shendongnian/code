        [Test]
        public void ReadFromBinaryFile2()
        {
            // Approach two
            using (var filestream = File.Open(@"C:\apps\test.bin", FileMode.Open))
            using (var binaryStream = new BinaryReader(filestream))
            {
                while (binaryStream.PeekChar() != -1)
                {
                    var integerFromFile = binaryStream.ReadInt32();
                }
            }
        }
