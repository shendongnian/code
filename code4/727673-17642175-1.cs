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
            Solve(list, solutions, solution);
        }
        private static void Solve(List<List<int>> list, List<int[]> solutions, int[] solution)
        {
            if (solution.All(i => i != 0) && !solutions.Any(s => s.SequenceEqual(solution)))
                solutions.Add(solution);
            for (int i = 0; i < list.Count; i++)
            {
                if (solution[i] != 0)
                    continue; // a caller up the hierarchy set this index to be a number
                for (int j = 0; j < list[i].Count; j++)
                {
                    if (solution.Contains(list[i][j]))
                        continue;
                    var solutionCopy = solution.ToArray();
                    solutionCopy[i] = list[i][j];
                    Solve(list, solutions, solutionCopy);
                }
            }
        }
