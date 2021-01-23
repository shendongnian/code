            // File.ReadAllLines method serves exactly the purpose you need
            List<string> lines = File.ReadAllLines(@"Data.txt").ToList();
            // lines.Max(line => line.Length) is used to find out the length of the longest line read from the file
            string[,] twoDim = new string[lines.Count, lines.Max(line => line.Length)];
            for(int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
                for(int charIndex = 0; charIndex < lines[lineIndex].Length; charIndex++)
                    twoDim[lineIndex,charIndex] = lines[lineIndex][charIndex].ToString();
            for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                for (int charIndex = 0; charIndex < lines[lineIndex].Length; charIndex++)
                    Console.Write(twoDim[lineIndex, charIndex]);
                
                Console.WriteLine();
            }
            Console.ReadKey();
