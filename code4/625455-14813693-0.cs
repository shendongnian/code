            List<string> lines = File.ReadAllLines(@"Data.txt").ToList();
            string[,] twoDim = new string[lines.Count,1000];
            for(int i=0; i<lines.Count; i++)
                for(int rowIndex=0; rowIndex<lines[i].Length; rowIndex++)
                    twoDim[i,rowIndex] = lines[i][rowIndex].ToString();
            for (int i = 0; i < lines.Count; i++)
            {
                for (int rowIndex = 0; rowIndex < lines[i].Length; rowIndex++)
                    Console.Write(twoDim[i, rowIndex]);
                Console.WriteLine();
            }
            Console.ReadKey();
