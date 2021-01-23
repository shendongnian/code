        static void Main(string[] args)
        {
            int[] numbers = {1, 1, 2, 2, 3, 3, 3, 3, 4, 5, 5};
            List<int> nums = new List<int>(numbers.Length);
            nums.AddRange(numbers);
            while (nums.Count > 0)
            {
                int[] n = nums.Distinct().ToArray();
                for (int i = 0; i < n.Count(); i++)
                {
                    Console.Write("{0}\t", n[i]);
                    nums.Remove(n[i]);
                }
                Console.WriteLine();
            }
            Console.Read();
        }
