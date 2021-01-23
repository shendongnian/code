    class Program
    {
        static void Main(string[] args)
        {
            var input = "1, 2, 3, 4, 4, 4, 1, 1, 2, 3, 4, 4 ";
            var list = input.Split(',').Select(i => i.Trim());
            var result = list
                .Select((s, i) => 
                    (s != list.Skip(i + 1).FirstOrDefault()) ? s : null)
                .Where(s => s != null)
                .ToList();
        }
    }
