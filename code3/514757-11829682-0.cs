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
