    if (columnHeader.Content.Equals("Class") || columnHeader.Content.Equals("Student"))
    {
        view.SortDescriptions.Clear();
        view.SortDescriptions.Add(new SortDescription("Class", ListSortDirection.Ascending));
        view.SortDescriptions.Add(new SortDescription("Student", ListSortDirection.Ascending));
    }
