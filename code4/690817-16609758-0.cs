    const int startVal = Int32.MaxValue - 1000000;
    Stopwatch sw = new Stopwatch();
    sw.Start();
    int i = startVal;
    try
    {
        while (i > 0)
        {
            unchecked
            {
                i++;
            }
        }
    }
    catch (ArithmeticException) {}
    sw.Stop();
    Console.WriteLine("Unchecked: " + sw.ElapsedTicks + "ms");
    i = startVal;
    sw.Restart();
    try
    {
        while (i > 0)
        {
            checked
            {
                i++;
            }
        }
    }
    catch (ArithmeticException) { }
    sw.Stop();
    Console.WriteLine("Checked: " + sw.ElapsedTicks + "ms");
