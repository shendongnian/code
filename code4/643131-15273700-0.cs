    static void Main(string[] args)
    {
        Console.WriteLine("GUESS THE ANSWER");
        
        
        int answer;
        var success = false;
        Console.WriteLine("Please enter the input");
        while (!success) {
           
           var userInput = Console.ReadLine();
           if (!Int32.TryParse(userInput, out answer) 
              Console.WriteLine("You must enter an integer");
    
           else {
              if (answer < 4)
                 Console.WriteLine("Too low");
    
              else if (answer > 4)
                 Console.WriteLine("Too high);
     
              else {
                 Console.WriteLine("Grats !");
                 success = true;
              }
            }
          if (!success)
             Console.WriteLine("Try again !");
         }
    }
        
