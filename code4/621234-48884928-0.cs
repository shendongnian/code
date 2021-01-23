    public class DataGridViewRowsAddedEventArgs : EventArgs
    {
      //The number of rows that have been added.
      public int RowCount { get; }
      //The index of the first added row.
      public int RowIndex { get; }
    }
