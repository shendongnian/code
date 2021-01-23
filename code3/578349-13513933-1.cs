    public static void Main(string[] args)
    {
        var list1 = new int?[] { 1, 2, 3, 4, 5 };
        var list2 = new int?[] { 3, 4, 5, 6, 7 };
        var list3 = new int?[] { 6, 9, 9 };
 
        var lockstep = LockStepSequences(new[] { list1, list2, list3 });
 
        foreach (var step in lockstep)
            Console.WriteLine(string.Join("\t", step.Select(i => i.HasValue ? i.Value.ToString() : "null").ToArray()));
    }
