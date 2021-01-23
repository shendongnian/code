    TestData verify = concurrentCache.AddOrUpdate(123, ci,
        (key, existingVal) =>
        {
            TestData newVal = existingVal.Copy();
            newVal.aStr2 = "test1" + newVal.QueryCount;
            newVal.aDate1 = DateTime.MinValue;
            Console.WriteLine("Thread:" + Thread.CurrentThread.ManagedThreadId + "  Query Count A:" + newVal.QueryCount);
            Interlocked.Increment(ref newVal.QueryCount);
            System.Random RandNum = new System.Random();
            int MyRandomNumber = RandNum.Next(1, 1000);
     
            Thread.Sleep(MyRandomNumber);
            newVal.aInt1++;
            newVal.aDate1 = newVal.aDate1.AddSeconds(newVal.aInt1);
            Console.WriteLine("Thread:" + Thread.CurrentThread.ManagedThreadId + "  Query Count B:" + newVal.QueryCount);
            return newVal;
        });
