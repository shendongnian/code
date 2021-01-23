    private bool sortAscending;
    private CommandStub _sortList;
    public ICommand sortList {
        get {
            if (_sortList == null) {
               _sortList = new CommandStub();
               _sortList.OnExecuting += new CommandStub.ExecutingEventHandler(_sortList_OnExecuting);
            }
    
            return _sortList;
       }
    }
    
    void _sortList_OnExecuting(object parameter) {
    
        var sortColumn = (string)parameter;
        StatusItems.SortDescriptions.Clear();
    
        if (sortAscending) {
            // Always sort first by GenericStatus
            StatusItems.SortDescriptions.Add(new SortDescription("GenericStatus", ListSortDirection.Ascending));
            // Sort by the column clicked
            StatusItems.SortDescriptions.Add(new SortDescription(sortColumn, ListSortDirection.Ascending));
            this.sortAscending = false;
        } else {
            // Always sort first by GenericStatus
            StatusItems.SortDescriptions.Add(new SortDescription("GenericStatus", ListSortDirection.Descending));
            StatusItems.SortDescriptions.Add(new SortDescription(sortColumn, ListSortDirection.Descending));
            this.sortAscending = true;
        }
    }
