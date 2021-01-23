            List<int> nums = new List<int>() { 8, 10, 12, 14, 16, 18, 20, 22, 24 };
            int width = 80;
            Console.WriteLine("Total width: " + width);
            Solver solver = new Solver();
            List<List<int>> res = solver.Solve(width, nums.ToArray());
            Console.WriteLine("total :" + res.Count);
            var res1 = res.Distinct(new SequenceComparer<List<int>, int>()).ToList();
            Console.WriteLine("total res1:" + res1.Count);
            var res2 = res1.Where(l => l.Count == 4).ToList();
            Console.WriteLine("total res2:" + res2.Count); //reduce to 4 integer solutions
            res2.Sort(new ZeroNormAndSDComparer());
