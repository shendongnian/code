        private static void NumberChange() 
        { 
            int new_range;
            Console.WriteLine("Please enter the number that the guess will start from."); 
            int.TryParse(Console.ReadLine(), out new_range); 
            from = new_range; 
            Console.WriteLine("Now enter the number that the guess will go to."); 
            int.TryParse(Console.ReadLine(), out new_range); 
            to = new_range; 
        } 
