    [Test]
    public void Y()
    {
        var sw = Stopwatch.StartNew();
        Parallel.For(0, 10, n => TestMethod("parallel", n));
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
        sw.Restart();
        for (int i = 0; i < 10; i++)
            TestMethod("forloop", i);
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
    }
    private static void TestMethod(string fileName, int hifi)
    {
        fileName = fileName + hifi;
        var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        var sw = new StreamWriter(fs, Encoding.UTF8);
        for (int x = 0; x < 10000; x++)
        {
            sw.WriteLine(DateTime.Now.ToString());
        }
        sw.Close();
    }
