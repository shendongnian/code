    int input1 = 0;
    while (input1 != 4)
          {
            input1 = (int.Parse(Console.ReadLine()));
          
            if (input1 == 4)
            {
                Console.WriteLine("You are a winner");
            }
            else if (input1 < 4)
            {
                Console.WriteLine("TOOOOO low");
              Console.WriteLine("Try agian");
    
            }
            else if (input1 > 4)
            {
                Console.WriteLine("TOOOO high");
              Console.WriteLine("Try agian");
    
            }    
    }
