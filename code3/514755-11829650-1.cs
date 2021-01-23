        if (ma.HowOldImI(date1, date2) < 30)
        {
            Console.WriteLine("you are too young to view this page");
            Console.WriteLine("would you like to continue the session?");
            string confirm = Console.ReadLine();
            if (confirm == "yes")
            {
                Console.WriteLine("Please type your name");
                string nm = Console.ReadLine();
                Console.WriteLine("Please type your born year");
                int ag = Convert.ToInt16(Console.ReadLine());
                gr.YouWereBorn(nm, ag);
            }
            else
            {
                return;
            }
        }
        else
        {
            Console.WriteLine("You are " + ma.HowOldImI(date1, date2) + " years old\n");
        }
