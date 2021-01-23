    [Pure]
    public static bool IsInRange(int? value)
    {
        return !value.HasValue
            || (value >= 0 && value <= 10);
    }
    public Employee(int? level)
    {
        Contract.Requires<ArgumentException>(IsInRange(level));
        Contract.Ensures(IsInRange(HierarchyLevel));
        this.HierarchyLevel = level;
    }
