    while(true)
     {
         Console.WriteLine("Your age:");
         string line = Console.ReadLine();
         if (!int.TryParse(line, out age))
            Console.WriteLine("{0} is not an integer", line);
         
         else break;
     }
