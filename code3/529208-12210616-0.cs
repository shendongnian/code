    PropertyInfo pi1 = typeof(x).GetProperty(sortColumn);
    PropertyInfo pi2 = typeof(y).GetProperty(sortColumn);
    
    //With sortColumn = "Login";
    if (sortDir == "ASC")
    {
        filteredList.Sort((x, y) => string.Compare(pi1.GetValue(x, null), pi2.GetValue(y, null), true));
    }
    else
    {
        filteredList.Sort((x, y) => string.Compare(pi2.GetValue(y, null), pi1.GetValue(x, null), true));
    }
