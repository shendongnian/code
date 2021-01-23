     class Program
    {
        static void Main(string[] args)
        {
            var listFruits = new List<string> { "Apple", "Banana", "Apple", "Mango" };
            if (FindDuplicates(listFruits)) { WriteLine($"Yes we find duplicate"); };
            ReadLine();
        }
        public static bool FindDuplicates(List<string> array)
        {
            var dict = new Dictionary<string, int>();
            foreach (var value in array)
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1;
            }
            foreach (var pair in dict)
            {
                if (pair.Value > 1)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }  
