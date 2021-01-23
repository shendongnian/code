        [Test]
        public void WriteToBinaryFile()
        {
            var ints = new[] {1, 2, 3, 4, 5, 6, 7};
            using (var filestream = File.Create(@"c:\apps\test.bin"))
            using (var binarystream = new BinaryWriter(filestream))
            {
                foreach (var i in ints)
                {
                    binarystream.Write(i);
                }
            }
        }
