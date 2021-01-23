                Console.WriteLine("Enter your Card Number");
                char[] card = Console.ReadLine().ToCharArray();
                int[] card_m = { 1, 2, 1, 2 };
                int counter = 0;
                foreach (char c in card)
                {
                    int value = (int)char.GetNumericValue(c) * card_m[counter++%card_m.Length];
                    Console.WriteLine("Converted Number: {0}", value);
                }
