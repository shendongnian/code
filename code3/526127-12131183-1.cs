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
                return other.Gaps - Gaps; // Less gaps is better
            return 0;
            // I don't understand this criterion so I'll just leave it our for now...
            // return MinGap - other.MinGap;
        }
    }
    private static IList<Task> F(IList<Task> tasks)
    {
        var end = tasks.Max(x => x.End);
        var tasksByTime = tasks.ToLookup(x => x.Start);
        var cache = new CacheEntry[end+1];
        cache[end] = new CacheEntry { Tasks = 0, Gaps = 0, MinGap = end + 1 };
    
        for (int t = end-1; t >= 0; t--)
        {
            if (!tasksByTime.Contains(t))
                cache[t] = cache[t+1];
            else
            {
                foreach (var task in tasksByTime[t])
                {
                    var oldCE = cache[t + task.Length];
                    var newCE = new CacheEntry
                    {
                        Tasks = oldCE.Tasks + 1,
                        Task = task,
                        NextTask = oldCE.Task,
                        Gaps = oldCE.Gaps,
                        MinGap = oldCE.MinGap
                    };
                    if (oldCE.Task != null && oldCE.Task.Start != task.End)
                    {
                        newCE.Gaps++;
                        newCE.MinGap = Math.Min(oldCE.MinGap, oldCE.Task.Start - task.End);
                    }
                    if (cache[t] == null)
                        cache[t] = newCE.CompareTo(cache[t + 1]) >= 0 ? newCE : cache[t + 1];
                    else
                        cache[t] = newCE.CompareTo(cache[t]) >= 0 ? newCE : cache[t];
                }
            }
        }
        var rv = new List<Task>();
        var curr = cache[0];
        while (true)
        {
            rv.Add(curr.Task);
            if (curr.NextTask == null) break;
            curr = cache[curr.NextTask.Start];
        }
        return rv;
    }
    public static void Main()
    {  
        var tasks = new List<Task>
        {
            new Task { Start = 0, Length = 2 },
            new Task { Start = 3, Length = 2 },
            new Task { Start = 4, Length = 2 },
            new Task { Start = 5, Length = 2 },
            new Task { Start = 6, Length = 2 },
            new Task { Start = 9, Length = 2 },
        };
        var sol = F(tasks);
        foreach (var task in sol)
            Console.Out.WriteLine(task);
        Console.In.ReadLine();
    }
