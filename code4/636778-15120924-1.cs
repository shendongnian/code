    using System;
    using System.Diagnostics;
    namespace ConsoleExamples
        {
            class ArrayComparePerformance
            {
                static readonly int testArraysNum = 100000;
                static readonly int maxArrayLen = 1500;
                static readonly int minArrayLen = 500;
                static readonly int maxValue = 10;
                public static void RunTest()
                {
                    //Generate random arrays;
                    ushort[][] a = new ushort[testArraysNum][];
                    ushort[][] b = new ushort[testArraysNum][];
                    Random rand = new Random();
                    Console.WriteLine("Generating test cases ... " );
            
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    for (int i = 0; i < testArraysNum; i++)
                    {
                        int len = rand.Next(maxArrayLen) + 1;
                        a[i] = new ushort[len];
                        for (int j = 0; j < len; j++)
                        {
                            a[i][j] = (ushort) rand.Next(maxValue);
                        }
                        len = rand.Next(maxArrayLen) + 1;
                        b[i] = new ushort[len];
                        for (int j = 0; j < len; j++)
                        {
                            b[i][j] = (ushort) rand.Next(maxValue);
                        }
                    }
                    sw.Stop();
                    Console.WriteLine("Done. ({0} milliseconds)", sw.ElapsedMilliseconds);
                    //compare1
                    sw.Restart();
                    for (int i = 0; i < testArraysNum; i++)
                    {
                        int result = Compare1(a[i], b[i]);
                    }
                    sw.Stop();
                    Console.WriteLine("Compare1 took " + sw.ElapsedMilliseconds.ToString() + " milliseconds");
                    //compare2
                    sw.Restart();
                    for (int i = 0; i < testArraysNum; i++)
                    {
                        int result = Compare2(a[i], b[i]);
                    }
                    sw.Stop();
                    Console.WriteLine("Compare2 took " + sw.ElapsedMilliseconds.ToString() + " milliseconds");
                    //compare3
                    sw.Restart();
                    for (int i = 0; i < testArraysNum; i++)
                    {
                        int result = Compare3(a[i], b[i]);
                    }
                    sw.Stop();
                    Console.WriteLine("Compare3 took " + sw.ElapsedMilliseconds.ToString() + " milliseconds");
                    //Generate "similar" arrays;
                    Console.WriteLine("Generating 'similar' test cases ... ");
                    sw.Restart();
                    for (int i = 0; i < testArraysNum; i++)
                    {
                        int len = rand.Next(maxArrayLen - minArrayLen) + minArrayLen -1;
                        a[i] = new ushort[len];
                        for (int j = 0; j < len; j++)
                        {
                            if (j < len/2)
                                a[i][j] = (ushort)j;
                            else
                                a[i][j] = (ushort)(rand.Next(2)  + j);
                        }
                        len = rand.Next(maxArrayLen - minArrayLen) + minArrayLen - 1;
                        b[i] = new ushort[len];
                        for (int j = 0; j < len; j++)
                        {
                            if (j < len/2)
                                b[i][j] = (ushort)j;
                            else
                                b[i][j] = (ushort)(rand.Next(2)  + j);
                        }
                    }
                    sw.Stop();
                    Console.WriteLine("Done. ({0} milliseconds)", sw.ElapsedMilliseconds);
                    //compare1
                    sw.Restart();
                    for (int i = 0; i < testArraysNum; i++)
                    {
                        int result = Compare1(a[i], b[i]);
                    }
                    sw.Stop();
                    Console.WriteLine("Compare1 took " + sw.ElapsedMilliseconds.ToString() + " milliseconds");
                    //compare2
                    sw.Restart();
                    for (int i = 0; i < testArraysNum; i++)
                    {
                        int result = Compare2(a[i], b[i]);
                    }
                    sw.Stop();
                    Console.WriteLine("Compare2 took " + sw.ElapsedMilliseconds.ToString() + " milliseconds");
                    //compare3
                    sw.Restart();
                    for (int i = 0; i < testArraysNum; i++)
                    {
                        int result = Compare3(a[i], b[i]);
                    }
                    sw.Stop();
                    Console.WriteLine("Compare3 took " + sw.ElapsedMilliseconds.ToString() + " milliseconds");
            
                    Console.ReadKey();
                }
                public static int Compare1(ushort[] x, ushort[] y)
                {
                    int pos = 0;
                    int len = Math.Min(x.Length, y.Length);
                    while (pos < len && x[pos] == y[pos])
                        pos++;
                    return pos < len ?
                        x[pos].CompareTo(y[pos]) :
                        x.Length.CompareTo(y.Length);
                }
                public unsafe static int Compare2(ushort[] x, ushort[] y)
                {
                    int pos = 0;
                    int len = Math.Min(x.Length, y.Length);
                    fixed (ushort* fpx = &x[0], fpy = &y[0])
                    {
                        ushort* px = fpx;
                        ushort* py = fpy;
                        while (pos < len && *px == *py)
                        {
                            px++;
                            py++;
                            pos++;
                        }
                    }
                    return pos < len ?
                        x[pos].CompareTo(y[pos]) :
                        x.Length.CompareTo(y.Length);
                }
                public static int Compare3(ushort[] x, ushort[] y)
                {
                    int pos = 0;
                    int len = Math.Min(x.Length, y.Length);
                    // the below is probably not worth it for less than 5 (or so) elements,
                    //   so just do the old way
                    if (len < 5)
                    {
                        while (pos < len && x[pos] == y[pos])
                            ++pos;
                        return pos < len ?
                          x[pos].CompareTo(y[pos]) :
                          x.Length.CompareTo(y.Length);
                    }
                    ushort lastX = x[len - 1];
                    bool lastSame = true;
                    if (x[len - 1] == y[len - 1])
                        --x[len - 1]; // can be anything else
                    else
                        lastSame = false;
                    while (x[pos] == y[pos])
                        ++pos;
                    return pos < len - 1 ?
                        x[pos].CompareTo(y[pos]) :
                        lastSame ? x.Length.CompareTo(y.Length)
                                 : lastX.CompareTo(y[len - 1]);
                }
            }
        }
