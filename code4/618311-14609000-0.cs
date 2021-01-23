            bool groceryListCheck = true;
            List<string> list = new List<string>();
            String item = null;
            String yon = null;
            int itemscount = 0;
            while (groceryListCheck)
            {
                Console.WriteLine("What item do you wanna go shop for?");
                item = Console.ReadLine();
                list.Add(item);
                Console.WriteLine("Done?");
                yon = Console.ReadLine();
                if (yon == "y")
                {
                    groceryListCheck = false;
                    itemscount = list.Count();
                }
                else
                {
                    groceryListCheck = true;
                }
            }
            for (int x = 0; x < itemscount; x++)
            {
                Console.WriteLine("Did you got the " + list[x] + "?");
                Console.ReadKey();
            }
