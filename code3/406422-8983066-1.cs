    DateTime dateValue;
    
    if (DateTime.TryParse(searchString, out dateValue))
    {
        leaves = leaves.Where(l => l.StartDate == dateValue);
    }
    else
    {
        leaves = leaves.Where(s => s.Employee.Name.ToUpper().Contains(searchString.ToUpper()));
    }
