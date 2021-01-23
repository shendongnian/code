    Stopwatch sw1 = new Stopwatch();
    Stopwatch sw2 = new Stopwatch();
    var ma = Enumerable.Range(1, 100000).Select(i => i.ToString()).ToArray();
    var x = ma.OfType<string>().ToArray();
    var y = ma.Cast<string>().ToArray();
    for (int i = 0; i < 1000; i++)
    {
        if (i%2 == 0)
        {
            sw1.Start();
            var arr = ma.OfType<string>().ToArray();
            sw1.Stop();
            sw2.Start();
            var arr2 = ma.Cast<string>().ToArray();
            sw2.Stop();
        }
        else
        {
            sw2.Start();
            var arr2 = ma.Cast<string>().ToArray();
            sw2.Stop();
            sw1.Start();
            var arr = ma.OfType<string>().ToArray();
            sw1.Stop();
        }
    }
    Console.WriteLine("OfType: " + sw1.ElapsedMilliseconds.ToString());
    Console.WriteLine("Cast: " + sw2.ElapsedMilliseconds.ToString());
    Console.ReadLine();
