    public IEnumerable<Employee> GetEmployees(Employee parent)
    {
        yield return parent;
        foreach (var child in boss.Children)
        {
            foreach (var grandChild in GetEmployees(child))
            {
                yield return grandChild;
            }
        }
    }
