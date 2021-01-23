        static byte[] ReadMemoryMappedFile(string fileName)
        {
            long length = new FileInfo(fileName).Length;
            using (var mmf = MemoryMappedFile.CreateFromFile(fileName, FileMode.Open, null, length, MemoryMappedFileAccess.Read))
            {
                using (var stream = mmf.CreateViewStream(0, length, MemoryMappedFileAccess.Read))
                {
                    using (BinaryReader binReader = new BinaryReader(stream))
                    {
                        var result = binReader.ReadBytes((int)length);
                        return result;
                    }
                }
            }
        }
