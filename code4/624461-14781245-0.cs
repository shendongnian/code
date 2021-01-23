       int choice;
       do
        {
            Console.WriteLine("Hi! This is a temperatue app");
            Console.WriteLine("Press 1 for C to F or 2 for F to C");
            //take the user input
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Great, you chose C to F. Now enter the temp.");
                int celcius = Convert.ToInt32(Console.ReadLine());
                //next line use the formula and show answer
            }
            if (choice == 2)
            {
                Console.WriteLine("Great, you chose F to C. Now enter the temp.");
                int fahrenheit = Convert.ToInt32(Console.ReadLine());
                //next line use the formula and show answer
            }
            else
                Console.WriteLine("That is not the right choice.");
                //In this way, keep asking the person for either 1 or two
        }
        while (choice != 1 || choice != 2);
        Console.ReadLine();
    }
}
