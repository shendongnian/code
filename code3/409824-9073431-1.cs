    IEnumerable<IEnumerable<int>> GetIndexes(int count)
    {
        for (ulong l = 0; l < Math.Pow(2, count); l++)
        {
            List<int> list = new List<int>();
            BitArray bits = new BitArray(BitConverter.GetBytes(l));
            for (int i = 0; i < sizeof(ulong); i++)
            {
                if (bits.Get(i)) list.Add(i);
            }
            yield return list;
        }
    }
    double[] nums = new double[] { 10,20,30,40,50,60,70,80,100 };
    Parallel.ForEach(GetIndexes(nums.Length), list =>
    {
        if (list.Select(n => nums[n]).Sum()==250)
        {
            Console.WriteLine(list.Aggregate("", (s, n) => s += nums[n] + " "));
        }
    });
