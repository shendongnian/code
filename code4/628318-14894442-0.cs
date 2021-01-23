    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> list = new List<int[]>();
            list.Add(new int[] { 10, 20, 30 });
            list.Add(new int[] { 10, 20, 30 });
            list.Add(new int[] { 10, 20, 30 });
            list.Add(new int[] { 10, 20, 30 });
            list.Add(new int[] { 10, 20, 30 });
            // The N
            int amountInCombination = 2;
            Dictionary<String, int> dictionary = new Dictionary<String, int>();
            foreach (int[] ints in list)
            {
                List<String> names = GetAllElemntCombinationsInRow(amountInCombination, ints);
                int count = 0;
                foreach (string name in names)
                {
                    if (dictionary.TryGetValue(name, out count))
                    {
                        dictionary[name]++;
                    }
                    else
                    {
                        dictionary.Add(name, 1);
                    }
                }
                
            }
            KeyValuePair<String, int> result = dictionary.OrderByDescending(e => e.Value).First();
            Console.WriteLine("{0} ({1})", result.Key, result.Value);
            //dictionary.OrderByDescending(e=>e.Value).First()
        }
        public static List<String> GetAllElemntCombinationsInRow(int amountInCombination, int[] row)
        {
            if (row.Count() < amountInCombination)
                throw new Exception("amount in row should be less than row elements count");
            List<String> result = new List<String>();
            List<String> iterationResult = new List<string>();
            for (int i = 0; i < row.Count(); i++)
            {
                if (amountInCombination != 1)
                {
                    int[] newRow = new int[row.Length - 1];
                    Array.Copy(row, 1, newRow, 0, row.Length - 1);
                    iterationResult = GetAllElemntCombinationsInRow(amountInCombination - 1, newRow);
                    for (int j = 0; j < iterationResult.Count; j++)
                    {
                        iterationResult[j] = row[i] + "," + iterationResult[j];
                    }
                }
                else
                {
                    result.Add(row[i].ToString());
                }
            }
            if (iterationResult.Count != 0)
                result = iterationResult;
            return result;
        }
    }
