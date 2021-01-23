    static void Main(string[] args)
    {
        string[] source = new string[1000000];
        for (int i = 0; i < source.Length; i++)
        {
            source[i] = "string " + i.ToString();
        }
        string[] buffer;
        Console.WriteLine("Starting stop watch");
        Stopwatch sw = new Stopwatch();
        for (int x = 0; x < 10; x++)
        {
            sw.Reset();
            sw.Start();
            for (int i = 0; i < source.Length; i += 100)
            {
                buffer = new string[100];
                Array.Copy(source, i, buffer, 0, 100);
            }
            sw.Stop();
            Console.WriteLine("Array.Copy: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
            sw.Start();
            for (int i = 0; i < source.Length; i += 100)
            {
                buffer = source.Skip(i).Take(100).ToArray();
            }
            sw.Stop();
            Console.WriteLine("Skip/Take: " + sw.ElapsedMilliseconds.ToString());
        }
        Console.ReadLine();
    }
