    class Program
    {
        static StreamWriter writer;
        static void Main(string[] args)
        {
            Debug.WriteLine("Start");
            writer = File.CreateText("\\test.txt");
            var start = Environment.TickCount;
            new Thread(WriteY).Start();
            for (int i = 0; i < 2500; i++)
            {
                writer.Write("+");
                Thread.Sleep(0);
            }
            var et = Environment.TickCount - start;
            Debug.WriteLine(string.Format("\r\nET: {0}ms", et));
            Thread.Sleep(1000);
            writer.Close();
            using(var reader = File.OpenText("\\test.txt"))
            {
                var content = reader.ReadToEnd();
                Debug.Writeline(content);
            }
        }
        static void WriteY()
        {
            for (int i = 0; i < 2500; i++)
            {
                writer.Write(".");
                Thread.Sleep(0);
            }
        }
    }
