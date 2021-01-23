        foreach (DataColumn dc in dt.Columns)
        {
            dt.Columns.Add(employeeTimings[i], typeof(string)); // Problem.
            i++;
        }
