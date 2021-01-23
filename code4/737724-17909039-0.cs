    string answer = "";
         do
         {
            Console.WriteLine("Continue? (yes/no)");
            answer = Console.ReadLine();
    
            if (answer.Equals("Y"))
            {
               Console.WriteLine("Yes");
            }
            else if (answer.Equals("N"))
            {
               Console.WriteLine("No");
            }
    
         } while (answer != "N");
