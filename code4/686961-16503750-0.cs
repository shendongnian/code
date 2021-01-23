    [AttributeUsage(AttributeTargets.Field)]
    class PriorityAttribute : Attribute { }
    [Flags]
    public enum Intervals
    {
        Root = PerfectUnison,
        Unison = PerfectUnison,
        [Priority]
        PerfectUnison = 1 << 0,
        AugmentedUnison = MinorSecond,
        [Priority]
        MinorSecond = 1 << 1,
        Second = MajorSecond,
        [Priority]
        MajorSecond = 1 << 2,
        AugmentedSecond = MinorThird,
        ...
