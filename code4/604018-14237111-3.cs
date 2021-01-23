    public static bool CompareLists(List<Employee> list1, List<Employee> list2)
    {
        if (list1 == null || list2 == null)
            return list1 == list2;
        if (list1.Count != list2.Count)
            return false;
        Dictionary<Employee, int> hash = new Dictionary<Employee, int>();
        foreach (Employee employee in list1)
        {
            if (hash.ContainsKey(employee))
            {
                hash[employee]++;
            }
            else
            {
                hash.Add(employee, 1);
            }
        }
        foreach (Employee employee in list2)
        {
            if (!hash.ContainsKey(employee) || hash[employee] == 0)
            {
                return false;
            }
            hash[employee]--;
        }
        return true;
    }
