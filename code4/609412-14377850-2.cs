    class Program
    {
        static List<List<int>> data;
        static List<int> list;
        static void Main(string[] args)
        {
            data = new List<List<int>>();
            for (int i = 0; i < 6; i++)
            {
                list = new List<int>();
                list.Add(1);
                list.Add(2);
                list.Add(1);
                var result = data
                    .Union(new[]{list})
                    .SelectMany(j => j)
                    .GroupBy(j => j)
                    .Select(j => new { j.Key, j })
                    .Where(j => j.j.Count() > 4);
                if (result.Count() == 0)
                    data.Add(list);
            }
        }
    }
