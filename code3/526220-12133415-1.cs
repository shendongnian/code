        static void Main(string[] args)
        {
            int count = 1000 * 1000;
            byte[] data = new byte[count];
            for (int i = 0; i < count; i++)
            {
                data[i] = (byte) i;
            }
            Stopwatch watch = new Stopwatch();
            for (int r = 0; r < 10; r++)
            {
                watch.Reset();
                watch.Start();
                int len = 0;
                foreach (var seg in data.MySplit(13))
                {
                    len += seg.Count;
                }
                watch.Stop();
                Console.WriteLine("MySplit      : {0} {1,8:N3} ms", len, watch.Elapsed.TotalMilliseconds);
                watch.Reset();
                watch.Start();
                ArraySplitter splitter = new ArraySplitter();
                int parts = splitter.Split(data, 13);
                len = 0;
                for (int i = 0; i < parts; i++)
                {
                    len += splitter[i].Count;
                }
                watch.Stop();
                Console.WriteLine("ArraySplitter: {0} {1,8:N3} ms", len, watch.Elapsed.TotalMilliseconds);
            }
        }
