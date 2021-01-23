    class Program
    {
        private static object N;
        static void Main(string[] args)
        {
            string answer;
            int runCount= 0;
            do
            {
              ++runCount;
              Console.WriteLine("please enter your name:");
              string name = Console.ReadLine();
              Console.WriteLine("please enter your surname:");
              string surname = Console.ReadLine();
              Console.WriteLine("please enter your age:");
              string age = int.Parse(Console.ReadLine());
              if(age >= 0 && age <= 10)
              {
                  Console.WriteLine("Child");
              }
              else if(age <= 20)
              {
                  Console.WriteLine("Young adult");
              }
              else if(age <= 65)
              {
                  Console.WriteLine("Adult");
              }
              Console.WriteLine("please enter your adress:");
              string adress = Console.ReadLine();
              Console.WriteLine("hallo,{0} {1},veel sucess met C#", name, surname);
              Console.WriteLine("zijn deze gegevens juist? J/N");
              answer = Console.ReadLine();
            }
            while(runCount < 3 && answer == "N");
        }
    }
