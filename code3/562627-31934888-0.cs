            string input;
            double price;
            bool result = false;
            while ( result == false )
                {
                Console.Write ("\n Enter the cost of the item : ");
                input = Console.ReadLine ();
                result = double.TryParse (input, out price);
                if ( result == false )
                    {
                    Console.Write ("\n Please Enter Numbers Only.");
                    }
                else
                    {
                    Console.Write ("\n cost of the item : {0} \n ", price);
                    break;
                    }
                }
