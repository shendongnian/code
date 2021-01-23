    int[] nums = Enumerable.Range(0, 1000000).ToArray();
    long total = 0;
    Parallel.ForEach(
        Partitioner.Create(0, nums.Length),
        () => 0,
        (part, loopState, partSum) =>
        {
            for (int i = part.Item1; i < part.Item2; i++)
            {
                partSum += nums[i];
            }
            return partSum;
        },
        (partSum) =>
        {
            Interlocked.Add(ref total, partSum);
        }
    );
