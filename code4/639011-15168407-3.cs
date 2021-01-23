    public void AddEmployee(Employee item)
    {
        // keep in mind this may not always be faster than List<T>.Sort
        // but it should be.
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
