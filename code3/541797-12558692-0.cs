            int count = 0;
            string myentry = "";
            for (count = 1; count < 10; count++)
            {
                Console.WriteLine("count=" + count);
                Console.WriteLine("Continue? Enter \"Y\" or \"N\"");
                myentry = Console.ReadLine().ToUpper();
                if (myentry=="N")
                {
                    break;
                }
            }
