        byte[] byteArray = new byte[1000000];
        for (int i = 0; i < byteArray.Length; i++)
        {
            byteArray[i] = Convert.ToByte(DateTime.Now.Second);
        }
        Stopwatch stopWatch = new Stopwatch();
        //#1 Manually creating and populating a new array;
        stopWatch.Start();
        
        byte[] extendedByteArray1 = new byte[byteArray.Length + 1];
        extendedByteArray1[0] = 0x00;
        for (int i = 0; i < byteArray.Length; i++)
        {
            extendedByteArray1[i + 1] = byteArray[i];
        }
        stopWatch.Stop();
        Console.WriteLine(string.Format("#1: {0} ms", stopWatch.ElapsedMilliseconds));
        stopWatch.Reset();
        //#2 Using a new array and Array.Copy
        stopWatch.Start();
        byte[] extendedByteArray2 = new byte[byteArray.Length + 1];
        extendedByteArray2[0] = 0x00;                                
        Array.Copy(byteArray, 0, extendedByteArray2, 1, byteArray.Length);
        stopWatch.Stop();
        Console.WriteLine(string.Format("#2: {0} ms", stopWatch.ElapsedMilliseconds));
        stopWatch.Reset();
        //#3 Using a List
        stopWatch.Start();
        List<byte> byteList = new List<byte>();
        byteList.AddRange(byteArray);
        byteList.Insert(0, 0x00);
        byte[] extendedByteArray3 = byteList.ToArray();
        stopWatch.Stop();
        Console.WriteLine(string.Format("#3: {0} ms", stopWatch.ElapsedMilliseconds));
        stopWatch.Reset();
        Console.ReadLine();
