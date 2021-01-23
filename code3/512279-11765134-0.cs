    public static void DoFizzBuzz()
    {
        var combinations = new Tuple<int, string>[]  
        {  
            new Tuple<int, string> (3, "Fizz"),  
            new Tuple<int, string> (5, "Buzz"),  
        };
        for (int i = 1; i <= 100; i++)
        {
            var fb = combinations.Where(t => {
                if (i % t.Item1 == 0)
                {
                    Console.Write(t.Item2);
                    return true;
                }
                return false;
            }).ToList();
            if (!fb.Any())
            {
                Console.Write(i);
            }
            Console.Write(Environment.NewLine);
        }
    } 
