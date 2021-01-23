         namespace ProgrammingTesting
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GUESS THE ANSWER");
            Console.WriteLine("Please enter the input");
            int input1 = 0;
            while (input1 != 4)
            {
                input1 = (int.Parse(Console.ReadLine()));
                if (input1 == 4)
                {
                    Console.WriteLine("You are a winner");
                    Console.ReadLine();
                }
                else if (input1 < 4)
                {
                    Console.WriteLine("TOOOOO low");
                    
                }
                else if (input1 > 4)
                {
                    Console.WriteLine("TOOOO high");
                    
                }
            }
        }
    }
