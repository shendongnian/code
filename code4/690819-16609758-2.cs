    const int startVal = Int32.MaxValue - 1000000;
    Stopwatch sw = new Stopwatch();
    sw.Start();
    int i = startVal;
    while (i < Int32.MaxValue)
    {
        unchecked
        {
            i++;
        }
    }
    sw.Stop();
    Console.WriteLine("Unchecked: " + sw.ElapsedTicks + " ticks");
    i = startVal;
    sw.Restart();
    while (i < Int32.MaxValue)
    {
        checked
        {
            i++;
        }
    }
    sw.Stop();
    Console.WriteLine("Checked: " + sw.ElapsedTicks + " ticks");
