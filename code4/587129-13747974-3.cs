        static void Main(string[] args)
        {
            Debug.WriteLine("Start");
            var writer = File.CreateText("\\test.txt");
            var start = Environment.TickCount;
            var are = new AutoResetEvent(false);
            var t = new Thread(delegate
                {
                    for (int i = 0; i < 2500; i++)
                    {
                        writer.Write(".");
                        Thread.Sleep(0);
                    }
                    // set an event signaling completion
                    are.Set();
                });
            t.Start();
            for (int i = 0; i < 2500; i++)
            {
                writer.Write("+");
                Thread.Sleep(0);
            }
            var et = Environment.TickCount - start;
            Debug.WriteLine(string.Format("\r\nET: {0}ms", et));
            // wait for the thread to complete
            are.WaitOne();
            // this would also work
            // t.Join();
            writer.Close();
            using(var reader = File.OpenText("\\test.txt"))
            {
                var content = reader.ReadToEnd();
                Debug.WriteLine(content);
            }
        }
