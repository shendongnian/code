            string list = "1,24,3,10,12,11";
            //Split the string into the tokens containing the numbers
            string[] tokens = list.Split(',');
            //Parse each string representing an integer into an integer
            //return the resultant object as an array of integers
            int[] sorting = tokens.Select(x => int.Parse(x)).ToArray<int>();
            //Sort them numerically and return as an array of integers
            sorting = sorting.OrderBy(x => x).ToArray<int>();
            //Display them to convince ourselves it works.
            foreach (int x in sorting)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
