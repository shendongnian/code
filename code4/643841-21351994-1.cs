     class Program
        {
            static void Main()
            {
                string str = "7788";
                int num1;
                bool n = int.TryParse(str, out num1);
                Console.WriteLine(num1);
                Console.ReadLine();
            }
        }
