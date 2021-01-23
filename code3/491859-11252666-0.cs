            int[] test = new int[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Please enter test " + i + 1);
                test[i] = Int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(test[i]);
                Console.ReadLine();
            }
