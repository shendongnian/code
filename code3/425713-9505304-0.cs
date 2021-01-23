    public class SourceRecord
    {
        public string SomeName { get; set; }
        public SourceRecord(string Name)
        {
            SomeName = Name;
        }
    }
    public void LoadData()
    {
        SourceRecord[] original = new SourceRecord[] { new SourceRecord("1"), new SourceRecord("3"), new SourceRecord("9") };
        GridColumn col = gridView1.Columns.AddVisible("SomeColumn");
        col.FieldName = "SomeName";
        gridControl1.DataSource = original;
    }
