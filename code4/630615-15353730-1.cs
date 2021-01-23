        static byte[] ReadMemoryMappedFile(string fileName)
        {
            long length = new FileInfo(fileName).Length;
            using (var stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var mmf = MemoryMappedFile.CreateFromFile(stream, null, length, MemoryMappedFileAccess.Read, null, HandleInheritability.Inheritable, false))
                {
                    using (var viewStream = mmf.CreateViewStream(0, length, MemoryMappedFileAccess.Read))
                    {
                        using (BinaryReader binReader = new BinaryReader(viewStream))
                        {
                            var result = binReader.ReadBytes((int)length);
                            return result;
                        }
                    }
                }
            }
        }
