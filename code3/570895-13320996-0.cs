            Console.Write("Enter you're first name: ");
            string fname = Console.ReadLine();
            foreach (var character in fname)
            {
                if (Char.IsDigit(character))
                    throw new Exception("Numbers are not allowed.");
            }
            Console.Write("You're Name is: " + fname);
