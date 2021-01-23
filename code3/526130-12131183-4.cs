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
            return MinGap - other.MinGap; // Larger minimum gap is better
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
            {
                cache[t] = cache[t + 1];
                continue;
            }
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
                // Otherwise we want the one that maximises MinGap.
                else
                {
                    var ce = oldCEs.OrderBy(x => Math.Min(x.Task.Start - newCE.Task.End, x.MinGap)).Last();
                    newCE.NextTask = ce.Task;
                    newCE.Gaps++;
                    newCE.MinGap = Math.Min(ce.MinGap, ce.Task.Start - task.End);
                }
                var toComp = cache[t] ?? cache[t + 1];
                if (newCE.CompareTo(toComp.First()) < 0)
                {
                    cache[t] = toComp;
                }
                else
                {
                    var ceList = new List<CacheEntry> { newCE };
                    // We need to keep track of all subsolutions X that start on the interval [T, T+L] that
                    // have an equal number of tasks and gaps, but a possibly a smaller MinGap. This is
                    // because an earlier task may have an even smaller gap to this task.
                    int idx = newCE.Task.Start + 1;
                    while (idx < newCE.Task.End)
                    {
                        toComp = cache[idx];
                        if
                        (
                            newCE.Tasks == toComp.First().Tasks &&
                            newCE.Gaps == toComp.First().Gaps &&
                            newCE.MinGap >= toComp.First().MinGap
                        )
                        {
                            ceList.AddRange(toComp);
                            idx += toComp.First().Task.End;
                        }
                        else
                            idx++;
                    }
                    cache[t] = ceList;
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
        Console.Out.WriteLine();
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
        Console.Out.WriteLine();
        tasks = new List<Task>
        {
            new Task { Start = 0, Length = 5 },
            new Task { Start = 6, Length = 5 },
            new Task { Start = 7, Length = 3 },
            new Task { Start = 8, Length = 9 },
            new Task { Start = 19, Length = 1 },
        };
        sol = F(tasks);
        foreach (var task in sol)
            Console.Out.WriteLine(task);
        Console.Out.WriteLine();
        Console.In.ReadLine();
    }
