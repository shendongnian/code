    private static readonly ReadOnlyCollecion<string> clerkDepartments =
        new ReadOnlyCollection<string>(
            new[] { "PURCHASING", "SCHED/PURCH", "SCHEDULING });
    public static readonly ReadOnlyCollection<string> ClerkDepartments
        { get { return clerkDepartments; } }
