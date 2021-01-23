    private bool HasDuplicates<T>(T gridList) where T: IGridList
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
