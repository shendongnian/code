            int[] arr1 = { 1155717, 5184305, 2531291, 1676341, 1916805 } ;
            int[] arr2 = { 1155717, 1440230, 2531291, 8178626, 1916805 };
            int[] arr3 = { 1155717, 5184305, 4025514, 1676341 };
            foreach (int i in arr1)
            {
                Console.Write(i + "  ");
                foreach (int b in arr2)
                {
                    if (i == b)
                        Console.Write(b + "  ");
                    
                }
                foreach (int c in arr3)
                {
                    if (i == c)
                        Console.Write(c + "  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
