        static void Main(string[] args)
        {
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            
            // supposed u need to find all the numbers which are greater then 5
            // in general it could have been done like
            foreach (int number in numbers)
            {
                if (number > 5)
                {
                    Console.WriteLine(number);
                }
                
            }
            // what if u needed the numbers that are greater then 5 multiple times, each time you would have to start a loop
            // yield return helps to return a collection of int
            var needed_numbers = NeededNumbers(numbers);
            foreach (int neededNumber in needed_numbers)
            {
                Console.WriteLine(neededNumber);
            }
        }
        private static IEnumerable<int> NeededNumbers(int[] nums)
        {
            foreach (int number in nums)
            {
                if (number > 5)
                {
                    yield return number;
                }
            }
        }
