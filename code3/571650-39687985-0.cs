    public void SetTestDataInGrid(List<List<object>> testData)
    {
        testGrid.Columns.Clear();
        int colCount = testData.Max(x => x.Count);
        for (int i = 0; i < colCount; i++)
        {
            var currentColumn = new DataGridTextColumn();
            currentColumn.Binding = new Binding(string.Format("[{0}]", i));
            testGrid.Columns.Add(currentColumn);
        }
        testGrid.ItemsSource = testData;
    }
