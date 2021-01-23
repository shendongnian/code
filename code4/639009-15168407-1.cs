    public void AddEmployee(Employee item)
    {
        if (employees.Count > 1)
        {
            var index = employees.BinarySearch(item);
            if (index < 0)
            {
                employees.Insert(~index, item);
            }
        }
        else employees.Add(item);
    }
