    public string BuildSortString(string sortColumn, SortDirection direction, string defaultColumn)
    {
        string sortDirection = direction.ToString();
        if (String.IsNullOrEmpty(sortColumn))
        {
            return VerifyColumn(defaultColumn);
        }
        return String.Format("{0} {1}", VerifyColumn(sortColumn), sortDirection);
    }
    private string VerifyColumn(string column)
    {
        switch (column) // fill this with a whitelist of accepted columns
        {
            case "some_column":
                return column;
        }
        return String.Empty; // the column must be invalid (do whatever you want here)
    }
    public enum SortDirection
    {
        ASC, DESC
    }
