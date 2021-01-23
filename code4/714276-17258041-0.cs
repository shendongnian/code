    class Program
        {
            static string[] letters = {"a", "b", "c"};
            static void dfs(string accum, int depth)
            {
                if (depth == 0)
                {
                    Console.WriteLine(accum);
                    return;
                }
                foreach (string c in letters)
                    dfs(accum + c, depth - 1);
            }
            static void Main(string[] args)
            {
                int depth = 5; //How many letters in each result
                dfs("", depth);
            }
        }
