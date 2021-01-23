        static Thread writer,
                      reader;
        static bool abort = false;
        
        static void Main(string[] args)
        {
            
            var fs = File.Create("D:\\test.txt");
            fs.Dispose();
            
            writer = new Thread(new ThreadStart(testWriteLoop));
            reader = new Thread(new ThreadStart(testReadLoop));
            writer.Start();
            reader.Start();
            Console.ReadKey();
            abort = true;
        }
        static void testWriteLoop()
        {
            using (FileStream fs = new FileStream("d:\\test.txt", FileMode.Open, FileAccess.Write, FileShare.Read))
            {
                using (var writer = new StreamWriter(fs))
                {
                    while (!abort)
                    {
                        writer.WriteLine(DateTime.Now.ToString());
                        writer.Flush();
                        Thread.Sleep(1000);
                    }
                }
            }
        }
        static void testReadLoop()
        {
            while (!abort)
            {
                Thread.Sleep(1000);
                using (var reader = new FileStream("d:\\test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var stream = new StreamReader(reader))
                    {
                        Console.WriteLine(stream.ReadToEnd());
                        stream.Close();
                    }
                    reader.Close();
                }
            }
        }
