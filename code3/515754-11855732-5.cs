    static void Main(string[] args)
    {
        int[] nums = { 1};            // base case == 0
        int[] nums2 = { 2, 1 };       // even case == 2
        int[] nums3 = { 1, 2, 1 };    // odd case == 3
        int[] nums4 = { 2, 1, 2 };    // flipped starting == 3
        int[] nums5 = { 2, 1, 2, 2, 1, 2, 1 }; // broken seqeuence == 4
        int[] nums6 = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 2, 2, 1, 2, 1 }; // long sequence == 14
        Console.WriteLine(max_alternate(nums));
        Console.WriteLine(max_alternate(nums2));
        Console.WriteLine(max_alternate(nums3));
        Console.WriteLine(max_alternate(nums4));
        Console.WriteLine(max_alternate(nums5));
        Console.WriteLine(max_alternate(nums6));
        Console.ReadLine();
    }
