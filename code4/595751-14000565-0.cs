            String input = Console.ReadLine();
            while (!((input[0] != 'N') || (input[0] != 'Y')))
            {
                input = Console.ReadLine();
            }
            if (input[0] == 'N')
            {
                Console.WriteLine("NO");
                Console.ReadKey();
            }
            else if (input[0] == 'Y')
            {
                Console.WriteLine("YES");
                Console.ReadKey();
            } 
