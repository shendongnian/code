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
        devicesView.SortDescriptions.Clear();
    
        if (sortAscending) {
            StatusItems.SortDescriptions.Add(new SortDescription(sortColumn, ListSortDirection.Ascending));
            this.sortAscending = false;
        } else {
            StatusItems.SortDescriptions.Add(new SortDescription(sortColumn, ListSortDirection.Descending));
            this.sortAscending = true;
        }
    }
