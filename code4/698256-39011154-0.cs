    public DataTable FullOuterJoinDataTables(params DataTable[] datatables) // supports as many datatables as you need.
    {
        DataTable result = datatables.First().Clone();
        var commonColumns = result.Columns.OfType<DataColumn>();
        foreach (var dt in datatables.Skip(1))
        {
            commonColumns = commonColumns.Intersect(dt.Columns.OfType<DataColumn>(), new DataColumnComparer());
        }
            
        result.PrimaryKey = commonColumns.ToArray();
        foreach (var dt in datatables)
        {
            result.Merge(dt, false, MissingSchemaAction.AddWithKey);
        }
        return result;
    }
    /* also create this class */
    public class DataColumnComparer : IEqualityComparer<DataColumn>
    {
        public bool Equals(DataColumn x, DataColumn y) => x.Caption == y.Caption;       
        public int GetHashCode(DataColumn obj) => obj.Caption.GetHashCode();        
    }
