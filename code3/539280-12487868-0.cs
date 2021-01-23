            var result = string.Empty;
            
            var search = Console.ReadLine();
            var words = Console.ReadLine();
            var first = words.Substring(0, 1);
            for (int i = 0; i < search.Length; i++)
            {
                if (i + 1 > search.Length) break;
                var bob = search.Substring(i, i + 2);
                if (bob == first)
                    result += bob.ToUpper();
            }
            Console.WriteLine(result);
