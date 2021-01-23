        const long iterations = 1000;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        //long sMem = GC.GetTotalMemory(true);
        ComplexStruct[] array = new ComplexStruct[1 << 20];
        for (int i = 0; i < array.Length; i++) {
            array[i] = new ComplexStruct();
        }
        //long eMem = GC.GetTotalMemory(true);
        //Console.WriteLine("memDiff=" + (eMem - sMem));
        //Console.WriteLine("mem/elem=" + ((eMem - sMem) / array.Length));
        Stopwatch sw = Stopwatch.StartNew();
        for (int k = 0; k < iterations; k++) {
            for (int i = 0; i < array.Length; i++) {
                array[i].Value0 = i;
            }
        }
        Console.WriteLine("{0,-15}  {1}   {2:n0} iterations/s",
            typeof(ComplexStruct).Name, sw.Elapsed, (iterations * array.Length) * 1000d / sw.ElapsedMilliseconds);
