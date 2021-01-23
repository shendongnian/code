    public class RowWrapper
    {
        public DataRow TheRow;
        public EType RowType;
        public Enum EType {
            Type1
            , Type2
            , ...
        }
        public RowWrapper(DataTable theRow, EType rowType)
        {
            this.TheRow = theRow;
            this.RowType = rowType;
        }
    }
    <...>
    this.myGrid.DataSource = Table1.AsEnumerable().Select(r => new RowWrapper(r, EType.Type1))
    .Union(Table2.AsEnumerable().Select(r => new RowWrapper(r, EType.Type2))
    .Union ...
