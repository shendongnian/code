        private static void Main()
        {
            List<List<int>> list = new List<List<int>>
                {
                    new List<int>() {1, 3, 6}, //Booking 1
                    new List<int>() {1, 2, 6}, //Booking 2
                    new List<int>() {1}, //Booking 3
                    new List<int>() {2, 3}
                };
            List<int[]> solutions = new List<int[]>();
            int[] solution = new int[list.Count];
            Solve(list, new HashSet<int>(), solutions, solution);
        }
        private static void Solve(List<List<int>> list, HashSet<int> numsUsed, List<int[]> solutions, int[] solution)
        {
            if (solution.All(i => i != 0) && !solutions.Any(s => s.SequenceEqual(solution)))
                solutions.Add(solution);
            for (int i = 0 ; i < list.Count;i++)
            {
                if (solution[i] != 0)
                    continue;
                for (int j=0;j<list[i].Count;j++)
                {
                    if (numsUsed.Contains(list[i][j]))
                        continue;
                    var s = solution.ToArray();
                    s[i] = list[i][j];
                    Solve(list,new HashSet<int>(numsUsed.Concat(new []{list[i][j]})),solutions,s);
                }
            }
        }
