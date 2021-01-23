    class Program
    {
        private static string[] letters = {"a", "b", "c"};
        private static void dfs(string accum, int depth)
        {
            if (depth == 0)
            {
                System.Console.WriteLine(accum);
                return;
            }
            foreach (string c in letters)
                dfs(accum + c, depth - 1);
        }
        public static void Main()
        {
            int depth = 2;
            dfs("", depth);
            System.Console.ReadLine();
        }
    }
