        public void FindCharRepetitions(string toCheck)
        {
            var result = new Dictionary<char, int>();
            foreach (var chr in toCheck)
            {
                if (result.ContainsKey(chr))
                {
                    result[chr]++;
                    continue;
                }
                result.Add(chr, 1);
            }
           
           foreach (var item in result)
           {
               Console.WriteLine("Char: {0}, Count: {1}", item.Key, item.Value);
           }
        }
