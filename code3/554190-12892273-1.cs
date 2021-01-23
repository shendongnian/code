    class Program
    {
        static void Main(string[] args)
        {
            //TASK: If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
            //Find the sum of all the multiples of 3 or 5 below 1000.
            int multiplierA = 3;
            int multiplierB = 5;
            int maxNum = 1000;
            int i = 1;
            int result = 0;
            List<int> deelEen = MultiplyFactory(multiplierA, i, maxNum);
            List<int> deelTwee = MultiplyFactory(multiplierB, i, maxNum);
            foreach (int val in deelEen)
                result += val;
            foreach (int val in deelTwee)
                if (!deelEen.Contains(val)) result += val;
            Console.WriteLine(result);
            Console.Read();
        }
        static List<int> MultiplyFactory(int multiplier, int i, int maxNum)
        {
            List<int> savedNumbers = new List<int>();
            while (multiplier * i < maxNum)
            {
                savedNumbers.Add(multiplier * i);
                i++;
            }
            return savedNumbers;
        }
    }
