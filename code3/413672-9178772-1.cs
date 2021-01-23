    private static void Main(string[] args)
    {
        string filePath = ...;   // Path to 2.5 GB file here
        Stopwatch z1 = new Stopwatch();
        Stopwatch z2 = new Stopwatch();
        int count = 10000;
        z1.Start();
        for (int i = 0; i < count; i++)
        {
            long length;
            using (Stream stream = new FileStream(filePath, FileMode.Open))
            {
                length = stream.Length;
            }
        }
        z1.Stop();
        z2.Start();
        for (int i = 0; i < count; i++)
        {
            long length = new FileInfo(filePath).Length;
        }
        z2.Stop();
        Console.WriteLine(string.Format("Stream: {0}", z1.ElapsedMilliseconds));
        Console.WriteLine(string.Format("FileInfo: {0}", z2.ElapsedMilliseconds));
        Console.ReadKey();
    }
