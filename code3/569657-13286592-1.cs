    public static IEnumerable<Employee> SortEmployees(
        IEnumerable<Employee> unsorted,
        OrderOptions options)
    {
        return unsorted.SortWithOptions(
            e => e.Cost,
            e => e.Ability,
            options);
    }
