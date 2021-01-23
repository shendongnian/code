            var result = new System.Text.StringBuilder();
            
            var search = Console.ReadLine();
            var words = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in words)
            {
                if (search.Contains(word))
                    result.Append(string.Format("{0},", word));
            }
            Console.WriteLine(result.ToString());
