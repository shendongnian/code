           double firstNo;
            while (true)
            {
                Console.Write("Enter First number:");
                string line = Console.ReadLine();
                if (!double.TryParse(line, out doubleVar)) //PARSE INT OR DOUBLE
                    Console.WriteLine("you must enter a number. {0} is not a number.", line);
                break;
            }
