    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> list = new List<int[]>();
            list.Add(new int[] { 10, 20, 30, 40, 50});
            list.Add(new int[] { 10, 20, 30, 40, 50 });
            list.Add(new int[] { 10, 20, 30, 40, 50 });
            list.Add(new int[] { 10, 20, 30, 40, 50 });
            list.Add(new int[] { 10, 20, 30, 40, 50 });
            // The N
            int amountInCombination = 4;
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
            List<String> result = new List<string>();
            List<String> tempUniq = new List<string>();
            for (int i = 0; i < row.Count(); i++)
            {
                tempUniq = new List<string>();
                if (amountInCombination != 1)
                {
                    int[] temp = new int[row.Length-i-1];
                    Array.Copy(row,i+1, temp,0,row.Length-i-1);
                    tempUniq = GetAllElemntCombinationsInRow(amountInCombination - 1, temp);
                }
                else
                {
                    result.Add(row[i].ToString());
                }
                if (tempUniq.Count != 0)
                {
                    for (int j = 0; j < tempUniq.Count; j++)
                    {
                        result.Add(row[i].ToString() + "," + tempUniq[j]);
                    }
                }
            }
            return result;
        }
    }
