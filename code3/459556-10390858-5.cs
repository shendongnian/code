     static void Main(string[] args)
            {
                try
                {
                    using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("testmap"))
                    {
                        Mutex mutex = Mutex.OpenExisting("testmapmutex");
                        mutex.WaitOne();
                        using (MemoryMappedViewStream stream = mmf.CreateViewStream(11, 0)) // From the 11 byte....
                        {
                            BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8);
                            writer.Write(2);
                        }
                        mutex.ReleaseMutex();
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Memory-mapped file does not exist. Run Process A first.");
                }
            }
