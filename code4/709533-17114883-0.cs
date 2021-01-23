    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Month, Day, Year separated by spaces");
            string input = Console.ReadLine();
            while (input != "0")
            {
                String[] nums = input.Split(' ');
                int month = Convert.ToInt32(nums[0]);
                int day = Convert.ToInt32(nums[1]);
                int year = Convert.ToInt32(nums[2]);
                if (month > 0 && month <= 12 &&
                    day > 0 && day <= 31 &&
                    year <= 2013)
                {
                    //valid
                }
                Console.WriteLine("Input Month, Day, Year separated by spaces");
                input = Console.ReadLine();
            }
        }
        
    }
    class myDateTime
    {
        public int Day;
        public int Month;
        public int Year;
        public myDateTime(int m, int d, int y)
        {
            Month = m;
            Day = d;
            Year = y;
        }
    }
