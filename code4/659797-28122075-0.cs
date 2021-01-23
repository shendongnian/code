    class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Input a number to find Prime numbers\n");
                int inp = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Prime Numbers are:\n------------------------------");
                int count = 0;
              
                for (int i = 1; i < inp; i++)
                {
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j != 0)
                        {
                            count += 1;
                        }
                    }
                    if (count == (i - 2))
                        {
                            Console.Write(i + "\t"); 
                        }
                    
                    count = 0;
                }
    
                Console.ReadKey();
    
            }
        }
