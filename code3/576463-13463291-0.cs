    string[] parts = theColumn.Split(',');
    if (parts.Length == 1)
    {
        // Find the last occurrence of ' ' and split first/last name based on that
        // People may have middle names entered e.g. Michael M. Myers
    }
    else if (parts.Length == 2)
    {
        firstName = parts[1];
        lastName = parts[0];
    }
    else
    {
        // Dealing with a more complex case like Myers, Jr., Michael
        // You will have to develop logic for such special cases that may
        // be in your data.
    }
