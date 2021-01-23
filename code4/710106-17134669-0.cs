        Array arr = Array.CreateInstance(typeof(int), 1000000);
        Stopwatch time = new Stopwatch();            
        
        Random random = new Random();
        for (int i = 0; i < arr.Length; i++) 
        {
            arr.SetValue(random.Next(10, 1000), i);
        }
        List<int> loopFor = new List<int>();
        time.Start();
        for (int i = 0; i < arr.Length; i++) 
        {
            int value = (int)arr.GetValue(i);
            if (value >= 200 && value <= 300) 
            {
                loopFor.Add(value);
            }
        }
        time.Stop();
        Console.WriteLine("Loop for: {0}", time.Elapsed);
        time.Reset();
        time.Start();
        List<int> loopForeach = new List<int>();
        foreach (int i in arr)
        {
            if (i >= 200 && i <= 300)
            {
                loopForeach.Add(i);
            }
        }
        time.Stop();
        Console.WriteLine("Loop foreach: {0}", time.Elapsed);
        time.Reset();
        time.Start();
        int[] matchedItems = Array.FindAll((int[])arr, x => x >= 200 && x <= 300);
        time.Stop();
        Console.WriteLine("Array.FindAll: {0}", time.Elapsed);
        Console.Read();
Result:
LoopFor: 1102804 milisseconds
Loop foreach: 1086569 milisseconds
Array.FindAll: 14 milisseconds (Better)
