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
        static private List<List<int>> Partitions(int X, int N, int Y)
        {
            List<List<int>> v = new List<List<int>>();
            if (X <= 1 || N == 1)
            {
                if (X <= Y)
                {
                    v.Add(new List<int>());
                    v[0].Add(X);
                }
                return v;
            }
            for (int y = Math.Min(X, Y); y >= 1; y--)
            {
                var w = Partitions(X - y, N - 1, y);
                for (int i = 0; i < w.Count; i++)
                {
                    w[i].Add(y);
                    v.Add(w[i]);
                }
            }
            return v;
        }
    }
