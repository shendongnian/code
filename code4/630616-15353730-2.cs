        private static void WriteData(string fileName, byte[] data)
        {
            using (var stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (var mmf = MemoryMappedFile.CreateFromFile(stream, null, data.Length, MemoryMappedFileAccess.ReadWrite, null, HandleInheritability.Inheritable, true))
                {
                    using (var view = mmf.CreateViewAccessor())
                    {
                        view.WriteArray(0, data, 0, data.Length);
                    }
                }
                stream.SetLength(data.Length);  // Make sure the file is the correct length, in case the data got smaller.
            }
        }
