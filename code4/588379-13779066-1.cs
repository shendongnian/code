                Generte_Sets(str, i + 1);
            else
            {
                for (int j = 0; j < sets.Count; j++)
                    Console.Write(sets[j]);
                Console.WriteLine();
            }
            sets.Remove(str[i].ToString());
          
