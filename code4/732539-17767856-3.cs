        class Program
        {
            //enum Menu
            //{
            //    Numbers = 1,
            //    Words = 2,
            //    Exit = 3,
            //}
    
            static void Main(string[] args)
            {
                bool isValid;
                do
                {
                    isValid = true;
                    int menu = 0;
                    int[] number;
                    string word;
                    
                    Console.WriteLine("Choose an option from the menu: ");
                    Console.WriteLine("1. Numbers ");
                    Console.WriteLine("2. Words ");
                    Console.WriteLine("3. Exit ");
                    
                    string s = Console.ReadLine();
                    while (!Regex.IsMatch(s, "^[1-3]{1}$"))
                    {
                        Console.WriteLine("Please enter a valid choice(1 to 3)");
                        s = Console.ReadLine();
                    }
                    menu = Convert.ToInt32(s);
                    switch (menu)
                    {
                        case 1:
                            List<int> numberarr = new List<int>();
                            Console.WriteLine("Please input as many numbers as you like separeted by space or comma,or type exit");
                            string numbers = Console.ReadLine();
                            if (numbers == "exit")
                                Choice.Exit();
                            else
                            {
                                number = numbers.Split(new char[] { ',', ' ' }).Select(x => int.Parse(x)).ToArray();
                                numberarr.AddRange(number);
                                Choice.Numbers(numberarr.Sum(), numberarr.Count, numberarr.Average(), numberarr.Max(), numberarr.Min());
                            }
    
                            break;
                        case 2:
                            List<string> wordarr = new List<string>();
                            Console.WriteLine("Please input as many numbers as you like separeted by space or comma");
                            word = Console.ReadLine();
                            wordarr.AddRange(word.Split(new char[] { ',', ' ' }));
                            Choice.Words(wordarr);
                            break;
                        case 3:
                            Choice.Exit();
                            break;
                        default:
                            Console.WriteLine("You have made an invalid selection, try again");
                            isValid = false;
                            break;
                    }
                } while (isValid);
                Console.ReadKey();
            }
        }
    
        class Choice
        {
            public static void Numbers(int sum, int count, double average, int max, int min)
            {
                int a = sum;
                int b = count;
                double c = average;
                int d = max;
                int e = min;
                //just as example.
            }
    
            public static void Words(List<string> args)
            {
                //do whatever you need here
            }
            public static void Exit()
            {
                Environment.Exit(0);
            }
        }
