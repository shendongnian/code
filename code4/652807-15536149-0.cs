         String input = "";
         while (input.Length < 14)
         {
            char c = Console.ReadKey(true).KeyChar;
            if (c >= 48 && c <= 57) // ASCII code for a digit (between 0 and 9)
            {
               input += c; // add digit to input
               Console.Write(c); // output it to the console
            }
            if (input.Length == 4 || input.Length == 7)
            {
               input += "-";
               Console.Write("-"); // add dash to the input and write it to console
            }
         }
