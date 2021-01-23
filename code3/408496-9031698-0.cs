            char responseFoodItem;
            Console.Write("Enter if food item or not (y/n): ");
            if (char.TryParse(Console.ReadLine(), out responseFoodItem))
            {
                // Set true or false to variable depending on the response
                if ((responseFoodItem == 'y' || responseFoodItem == 'Y'))
                {
                    Console.WriteLine("foodItem = true");
                }
                else if ((responseFoodItem == 'n' || responseFoodItem == 'N'))
                {
                    Console.WriteLine("foodItem = false");
                }
                else
                {
                    Console.WriteLine("Unrecognised input");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
