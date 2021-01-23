    static void Main(string[] args)
    {
       const int QUIT = -1;
       string inputStr;
       int inputInt = 0;
       Queue myQ = new Queue();
       do
       {
          Console.Write("Type a number (type -1 to quit): ");
          inputStr = Console.ReadLine();
          bool inputBool = int.TryParse(inputStr, out inputInt);
    
          if (inputBool == true)
          {
             if (myQ.Count() == 3)
             {
                myQ.Dequeue();
                myQ.Enqueue(inputInt);
             }
             else
             {
                myQ.Enqueue(inputInt);
             } 
          }
          
          if (myQ.Count() == 3)
          {
             Console.WriteLine("Sum of the past three numbers is: {0}", myQ.Sum());
          }
    
       } while (inputInt != QUIT);
    
    }
