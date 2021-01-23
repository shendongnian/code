        public static void sortstrings(string[] input1)
        {
            output1 = input1.Select(word => new string(word.OrderBy(i => i).ToArray())).ToArray();
            
            foreach (var item in output1)
            {
                Console.WriteLine(item);
            }
        }
