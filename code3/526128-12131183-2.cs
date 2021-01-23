    private class Task
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public int End { get { return Start + Length; } }
        public override string ToString()
        {
            return string.Format("({0:d}, {1:d})", Start, End);
        }
    }
    private class CacheEntry : IComparable
    {
        public int Tasks { get; set; }
        public int Gaps { get; set; }
        public int MinGap { get; set; }
        public Task Task { get; set; }
        public Task NextTask { get; set; }
        public int CompareTo(object obj)
        {
            var other = obj as CacheEntry;
            if (Tasks != other.Tasks)
                return Tasks - other.Tasks; // More tasks is better
            if (Gaps != other.Gaps)
                return other.Gaps = Gaps; // Less gaps is better
            return other.MinGap - MinGap; // Larger minimum gap is better
        }
    }
    private static IList<Task> F(IList<Task> tasks)
    {
        var end = tasks.Max(x => x.End);
        var tasksByTime = tasks.ToLookup(x => x.Start);
        var cache = new List<CacheEntry>[end + 1];
        cache[end] = new List<CacheEntry> { new CacheEntry { Tasks = 0, Gaps = 0, MinGap = end + 1 } };
        for (int t = end - 1; t >= 0; t--)
        {
            if (!tasksByTime.Contains(t))
                cache[t] =cache[t + 1];
            else
            {
                foreach (var task in tasksByTime[t])
                {
                    var oldCEs = cache[t + task.Length];
                    var firstOldCE = oldCEs.First();
                    var lastOldCE = oldCEs.Last();
                    var newCE = new CacheEntry
                    {
                        Tasks = firstOldCE.Tasks + 1,
                        Task = task,
                        Gaps = firstOldCE.Gaps,
                        MinGap = firstOldCE.MinGap
                    };
                    // If there is a task that starts at time T + L, then that will always 
                    // be the best option for us, as it will have one less Gap than the others
                    if (firstOldCE.Task == null || firstOldCE.Task.Start == task.End)
                    {
                        newCE.NextTask = firstOldCE.Task;
                    }
                    // Otherwise we want the last one as later starting time = larger gap.
                    else
                    {
                        newCE.NextTask = lastOldCE.Task;
                        newCE.Gaps++;
                        newCE.MinGap = Math.Min(lastOldCE.MinGap, lastOldCE.Task.Start - task.End);
                    }
                    var toComp = cache[t] ?? cache[t + 1];
                    // If the two options are equal, we need to keep track of both. toComp.Last()
                    // starts later, so allows the possibility of a larger MinGap, but if there is a 
                    // task that ends at the current start time, newCE will be better as it will result
                    // in one less Gap.
                    if 
                    (
                        newCE.Tasks == toComp.First().Tasks &&
                        newCE.Gaps == toComp.First().Gaps &&
                        newCE.MinGap >= toComp.First().MinGap
                    )
                        cache[t] = new List<CacheEntry> { newCE, toComp.Last() };
                    else
                        cache[t] = newCE.CompareTo(toComp.First()) > 0 ? new List<CacheEntry> { newCE } : toComp;
                }
            }
        }
        var rv = new List<Task>();
        var curr = cache[0].First();
        while (true)
        {
            rv.Add(curr.Task);
            if (curr.NextTask == null) break;
            curr = cache[curr.NextTask.Start].First();
        }
        return rv;
    }
    public static void Main()
    {
        IList<Task> tasks, sol;
        tasks = new List<Task>
        {
            new Task { Start = 0, Length = 2 },
            new Task { Start = 3, Length = 2 },
            new Task { Start = 4, Length = 2 },
            new Task { Start = 5, Length = 2 },
            new Task { Start = 6, Length = 2 },
            new Task { Start = 9, Length = 2 },
        };
        sol = F(tasks);
        foreach (var task in sol)
            Console.Out.WriteLine(task);
        Console.Out.WriteLine("");
        tasks = new List<Task>
        {
            new Task { Start = 0, Length = 2 },
            new Task { Start = 3, Length = 2 },
            new Task { Start = 4, Length = 2 },
            new Task { Start = 8, Length = 2 },
        };
        sol = F(tasks);
        foreach (var task in sol)
            Console.Out.WriteLine(task);
        Console.In.ReadLine();
    }
