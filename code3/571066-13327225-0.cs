        static void Main()
        {
            var file = @"c:\temp\test.bin";
            String huge = new String(new char[100 * 1024 * 1024]);
            var sw = new Stopwatch();
            var sw2 = new Stopwatch();
            sw.Start();
            using (var stream = new StreamWriter(file))
            {
                sw2.Start();
                stream.Write(huge);
                sw2.Stop();
            }
            sw.Stop();
            sw2.Stop();
            Console.WriteLine("Write 20MB to cache: " + (sw.Elapsed.TotalMilliseconds - sw2.Elapsed.TotalMilliseconds));
            Console.WriteLine("Write 20MB from cache to HD: " + sw2.Elapsed.TotalMilliseconds);
        }
