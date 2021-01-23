            string input = Console.ReadLine();
            if (input.Contains("north") && input.Contains("east")) 
                Console.WriteLine("\nyou head north east");
            else if (input.Contains("north")) 
                Console.WriteLine("\nyou head north");
            else if (input.Contains("east")) 
                Console.WriteLine("\nyou head east");
            else if (input.Contains("south")) 
                Console.WriteLine("\nyou head south");
            else if (input.Contains("west"))                    
                Console.WriteLine("\nyou head west");
            else 
                Console.WriteLine("enter a valid direction");
