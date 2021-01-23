    public class TableViewModel
    {
      public string Title { get; set; }
      public IEnumerable<Row> Rows { get; set; }
      public Row ForNames = null;
    }
    @Html.DisplayNameFor(x => x.ForName.ColumnA)
