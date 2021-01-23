           double firstNo;
            while (true)
            {
                Console.Write("Enter First number:");
                string line = Console.ReadLine();
                if (!double.TryParse(line, out firstNo)) //INT OR A DOUBLE
                    Console.WriteLine("you must enter a number. {0} is not a number.", line);
                break;
            }
