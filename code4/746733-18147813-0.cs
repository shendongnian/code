                int num;
                Console.WriteLine("give me a number equal or above 3!");
                int.TryParse(Console.ReadLine(),out num);
                int i = 0;
                List<int> nums = new List<int>();
                i += 3;
                while (i <= num)
                {
                    nums.Add(i);
                    i += 3;
                }
    
                Console.Write("Numbers are: ");
                foreach (int y in nums)
                {
                    Console.Write(y + " , ");
                }
                Console.WriteLine("The remainder is " + (num - nums[nums.Count - 1]));
