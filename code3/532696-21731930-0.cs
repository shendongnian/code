        Console.WriteLine("How many students would you like to enter?");
            string amount = Console.ReadLine();
            int amt = Convert.ToInt32(amount);
            Console.WriteLine("{0} {1}", "amount equals", amount);
            for (int i = 0; i < amt; i++)
            {
                Console.WriteLine("Input the name of a student");
                String StudentName = Console.ReadLine();
                Console.WriteLine("the Students name is " + StudentName);
            }
            //thats it
