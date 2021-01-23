    double[] nums = new double[] { 10,20,30,40,50,60,70,80,90,100,150,200,250,300,400,500};
    Parallel.ForEach(GetIndexes(nums.Length), list =>
    {
        if (list.Select(n => nums[n]).Sum()==350)
        {
            Console.WriteLine(list.Aggregate("", (s, n) => s += nums[n] + " "));
        }
    });
    IEnumerable<IEnumerable<int>> GetIndexes(int count)
    {
        for (ulong l = 0; l < Math.Pow(2, count); l++)
        {
            List<int> list = new List<int>();
            BitArray bits = new BitArray(BitConverter.GetBytes(l));
            for (int i = 0; i < sizeof(ulong)*8; i++)
            {
                if (bits.Get(i)) list.Add(i);
            }
            yield return list;
        }
    }
