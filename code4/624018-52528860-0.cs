    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = new[] { 800, 11, 50, 771, 649, 770, 240, 9 };
            BubbleSort(input);
            Array.ForEach(input, Console.WriteLine);
            Console.ReadKey();
        }
        public enum Direction
        {
            Ascending = 0,
            Descending
        }
        public static void BubbleSort(int[] input, Direction direction = Direction.Ascending)
        {
            bool swapped;
            var length = input.Length;
            
            do
            {
                swapped = false;
                for (var index = 0; index < length - 1; index++)
                {
                    var needSwap = direction == Direction.Ascending ? input[index] > input[index + 1] : input[index] < input[index + 1];
                    if (needSwap)
                    {
                        var temp = input[index];
                        input[index] = input[index + 1];
                        input[index + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
