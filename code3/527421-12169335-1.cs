    public void ParallelOne()
        {
            int[] nums = Enumerable.Range(0, 8).ToArray();
            Debug.WriteLine(nums.Count().ToString() + " " + nums[nums.Count()-1].ToString());
            long total = 0;
    
    
            for (int k = 0; k < 2; k++)
            {
                total = 0;
                // Use type parameter to make subtotal a long, not an int
                Parallel.For<long>(k*4, (k+1)*4, () => 0, (j, loop, subtotal) =>
                {
                    subtotal += nums[j];
                    Debug.WriteLine(subtotal.ToString() + " " + j.ToString());
                    return subtotal;
                },
                    (x) => Interlocked.Add(ref total, x)
                );
    
                Debug.WriteLine("The total is {0}", total);
            }
    
        }
