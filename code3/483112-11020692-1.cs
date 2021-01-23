    class Program
    {
        static void Main(string[] args)
        {
            var v = Partitions(5, 3, 5);
            
            for (int i = 0; i < v.Count; i++)
            {
                for (int x = 0; x < v[i].Count; x++)
                    Console.Write(v[i][x] + " "); 
                Console.WriteLine();
            }
        }
        static private List<List<int>> Partitions(int total, int stacks, int max)
        {
            List<List<int>> partitions = new List<List<int>>();
            if (total <= 1 || stacks == 1)
            {
                if (total <= max)
                {
                    partitions.Add(new List<int>());
                    partitions[0].Add(total);
                }
                return partitions;
            }
            for (int y = Math.Min(total, max); y >= 1; y--)
            {
                var w = Partitions(total - y, stacks - 1, y);
                for (int i = 0; i < w.Count; i++)
                {
                    w[i].Add(y);
                    partitions.Add(w[i]);
                }
            }
            return partitions;
        }
    }
