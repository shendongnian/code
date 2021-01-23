    namespace ConsoleApplicationCSharp1
    {
      class Program
      {
        static void Main(string[] args)
        {
            String command;
            Boolean quitNow = false;
            while(!quitNow)
            {
               command = Console.ReadLine();
               switch (command)
               {
                  case "/help":
                    Console.WriteLine("This should be help.");
                     break;
    
                   case "/version":
                     Console.WriteLine("This should be version.");
                     break;
    
                    case "/quit":
                      quitNow = true;
                      break;
    
                    default:
                      Console.WriteLine("Unknown Command " + command);
                      break;
               }
            }
         }
      }
    }
