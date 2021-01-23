    bool CompareTables(Table source, Table destination)
    {
        // Column count doesn't match
        if (!source.Columns.Count.Equals(destination.Columns.Count))
            return false;
        // Assuming the order of the Columns are same in both the Tables
        for (int i = 0; i < source.Columns.Count; i++)
            if (!source.Columns[i].Equals(destination.Columns[i]))
                return false;
        // Constraints count doesn't match
        if (!source.Checks.Count.Equals(destination.Checks.Count))
            return false;
        // Assuming the order of the Contraints are same in both the Tables
        for (int i = 0; i < source.Checks.Count; i++)
            if (!source.Checks[i].Equals(destination.Checks[i]))
                return false;
        return true;
    }
