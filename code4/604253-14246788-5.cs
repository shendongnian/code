    private bool HasDuplicates(IGridList gridList)
    {
        // Both FirstGridList and SecondGridList have a method FindDuplicates
        // that both return a List<string>
        var duplicates = gridList.FindDuplicates();
        if (duplicates.Count > 0)
        {
            // Do Something
            return true;
        }
        return false;
    }
