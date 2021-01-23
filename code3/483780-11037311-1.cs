    public class MyViewModel
    {
        // same number of column names as numbers of items in each RowDataItem
        public IList<string> ColumnNames{get; private set; }
        public IList<RowDataItem> Items{ get; private set; }
    }
