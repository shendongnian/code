    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("RandNumb(rd, 1, 10, 2)=" + RandNumb(rd, 1, 10, 2));
                Console.WriteLine("RandNumb(rd, 100, 1000, 500)=" + RandNumb(rd, 100, 1000, 500));
                Console.WriteLine("RandNumb(rd, 0.001, 0.1, 0.01) =" + RandNumb(rd, 0.001, 0.1, 0.01)); 
            }
            Console.ReadLine();
        }
    
        public static double RandNumb(Random rd, double min, double max, double step)
        {
            int range = (int)Math.Floor((max - min) / step);
            int stepCount = rd.Next(0, range + 1);
            return min + (step * stepCount);
        }
    }
