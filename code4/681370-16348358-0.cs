        int userInput = -1;
        while (true){
          Console.WriteLine("Input value:");
          try{
            userInput = Int.Parse(Console.ReadLine());
            if (userInput <1 || userInput >5){
              throw new Exception();
            }
          }
          catch{
            Console.WriteLine("Invalid input");
            continue;
          }
          break;
        }
