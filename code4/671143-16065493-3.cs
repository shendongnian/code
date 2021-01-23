    IList<DataItem> items = BuildDataGridColumns(cultureDict).Tables[0].AsDataView();
    this.DataItems = new ObservableCollection<DataItem>(items);
    
    ...
    
    private IList<DataItem> BuildDataGridColumns(Dictionary<string, string> cultureDict,
                                         DataTable additionalDt = null)
    {
        // ... here create a list of DataItems from your table, and return it.
    }
