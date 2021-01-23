    class Program
    {
        const int SIZE = 6;
        static void Main(string[] args)
        {
            double min = 0.0;
            double max = 0.0;
            double ave = 0.0;
            double total = 0.0;
            double[] numbers = new double[SIZE];
            getInput(numbers);
            calcmin(numbers, ref min);
            calcmax(numbers, ref max);
            calcTotal(numbers, ref total);
            calcave(numbers, ref ave,  total);
            printResult(numbers, ref min, ref max, ref ave, ref total);
            Console.ReadLine();
        }
        static void calcave(double[] numbers, ref double ave,  double total)
        {
            ave = total / numbers.Length;
        }
        static void calcTotal(double[] numbers, ref double total)
        {
            int sub = 0;
            while (sub < numbers.Length)
            {
                total = numbers[sub] + total;
                sub++;
            }
        }
        static void calcmax(double[] numbers, ref double max)
        {
            int sub = 0;
            max = numbers[0];
            while (sub < numbers.Length)
            {
                if (numbers[sub] > max)
                {
                    max = numbers[sub];  //HERE
                }
                sub++;
            }
        }
        static void calcmin(double[] numbers, ref double min)
        {
            int sub = 0;
            min = numbers[0];
            while (sub < numbers.Length)
            {
                if (numbers[sub] < min)
                {
                    min = numbers[sub];  //HERE
                }
                sub++;
            }
        }
        static void getInput(double[] numbers)
        {
            int sub = 0;
            for (sub = 0; sub < numbers.Length; sub++)
            {
                Console.WriteLine("Enter number {0}", sub + 1);
                while (!double.TryParse(Console.ReadLine(), out numbers[sub]))
                    Console.WriteLine("Please try again.");
            }
        }
        static void printResult(double[] numbers, ref double min, ref double max, ref double ave, ref double total)
        {
            Console.WriteLine("The smallest number is {0}.", min);
            Console.WriteLine("the largest number is {0}.", max);
            Console.WriteLine("the total is {0}.", total);
            Console.WriteLine("The average is {0}.", ave);
        }
    }
