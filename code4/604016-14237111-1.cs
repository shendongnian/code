    public static bool CompareLists(List<Employee> list1, List<Employee> list2)
    {
        if (list1 == null || list2 == null)
            return list1 == list2;
        if (list1.Count != list2.Count)
            return false;
        HashSet<Employee> hash = new HashSet<Employee>(list1);
        foreach (Employee employee in list2)
        {
            if (!hash.Contains(employee))
            {
                return false;
            }
            hash.Remove(employee);
        }
        return true;
    }
