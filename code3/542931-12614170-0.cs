    void LoadNextColumns(List<ColumnDisplaySetup> colDef, int startIdx, int numToLoad)
    {
        for (int idx = startIdx; idx < startIdx + numToLoad && idx < colDef.Count; idx++)
        {
            DataGridTextColumn newCol = new DataGridTextColumn();
            newCol.Header = colDef[idx].Header;
            newCol.Binding = new Binding() { Path = new PropertyPath(colDef[idx].Property) };
            dgMainGrid.Columns.Add(newCol);
        }
        if (startIdx + numToLoad < colDef.Count)
        {
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                        LoadNextColumns(colDef, startIdx + numToLoad, numToLoad);
                });
        }
    }
