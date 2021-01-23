    class Program
    {
        static Int32[] nums = { 1, 2, 5, 3, 6, -1, -2, 10, 11, 12 };
        static Int32 sum = 10;
        static Int32 maxNums = 3;
        static Int32[] selectedNums = new Int32[maxNums];
    
        static void Main(string[] args)
        {
            CurrentSum(0, 0, 0);
            Console.ReadLine();
        }
    
        public static void Print(int count)
        {
            for (Int32 i = 0; i < count; i++)
            {
                Console.Write(" " + selectedNums[i]);
            }
            Console.WriteLine();
        }
    
        public static void CurrentSum(Int32 sumSoFar, Int32 numsUsed, Int32 startIndex)
        {
            if (sumSoFar == sum && numsUsed <= maxNums)
            {
                Print(numsUsed);
            }
    
            if (numsUsed >= maxNums || startIndex >= nums.Length)
                return;
    
            for (int i = startIndex; i < nums.Length; i++)
            {
                // Include i'th number
                selectedNums[numsUsed] = nums[i];
                CurrentSum(sumSoFar + nums[i], numsUsed + 1, i + 1);
            }
        }
    }
