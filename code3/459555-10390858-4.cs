     static void Main(string[] args)
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("testmap", 4000))
                {
                    bool mutexCreated;
                    Mutex mutex = new Mutex(true, "testmapmutex", out mutexCreated);
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        string st = "Hellow";
                        int stringSize = Encoding.UTF8.GetByteCount(st); //6
                        writer.Write(st);
                        writer.Write(123); //6+4 bytes = 10 bytes
                    }
                    mutex.ReleaseMutex();
                    Console.WriteLine("Start Process B and press ENTER to continue.");
                    Console.ReadLine();
                    mutex.WaitOne();
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        Console.WriteLine("Process  A  says: {0}", reader.ReadString());
                        Console.WriteLine("Process  A says: {0}", reader.ReadInt32());
                        Console.WriteLine("Process  B says: {0}", reader.ReadInt32());
                    }
                    mutex.ReleaseMutex();
                }
            }
