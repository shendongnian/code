    private static double[] Foo1(IList<double> y, int halfWindowWidth)
    {
        var yfiltered = new double[y.Count];
        var yLength = y.Count;
        
        for (var i = 0; i < yLength; i++)
        {
            var sum = 0.0;
            
            for (var k = i - halfWindowWidth; k <= i + halfWindowWidth; k++)
            {
                sum += y[(k + yLength) % yLength];
            }
            
            yfiltered[i] = sum / (2 * halfWindowWidth + 1);
        }
        return yfiltered;
    }
        
    private static double[] Foo2(IList<double> y, int halfWindowWidth)
    {
        var yFiltered = new double[y.Count];
        var windowSize = 2 * halfWindowWidth + 1;
        double sum = 0;
        for (var i = -halfWindowWidth; i <= halfWindowWidth; i++)
        {
            sum += y[(i + y.Count) % y.Count];
        }
        yFiltered[0] = sum / windowSize;
        for (var i = 1; i < y.Count; i++)
        {
            sum = sum -
                  y[(i - halfWindowWidth - 1 + y.Count) % y.Count] +
                  y[(i + halfWindowWidth) % y.Count];
            yFiltered[i] = sum / windowSize;
        }
        return yFiltered;
    }
        
    private static TimeSpan TestFunc(Func<IList<double>, int, double[]> func, IList<double> y, int halfWindowWidth, int iteration
    {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < iterations; i++)
        {
            var yFiltered = func(y, halfWindowWidth);
        }
        sw.Stop();
        return sw.Elapsed;
    }
    private static void RunTests()
    {
        var y = new List<double>();
        var rand = new Random();
        for (var i = 0; i < 1000; i++)
        {
            y.Add(rand.Next());
        }
        var foo1Res = Foo1(y, 100);
        var foo2Res = Foo2(y, 100);
        Debug.WriteLine("Results are equal: " + foo1Res.SequenceEqual(foo2Res));
        Debug.WriteLine("Foo1: " + TestFunc(Foo1, y, 100, 1000));
        Debug.WriteLine("Foo2: " + TestFunc(Foo2, y, 100, 1000));
    }
