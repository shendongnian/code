    public static class DataTableExtensions
    {
        private sealed class Row : DynamicObject
        {
            private readonly DataRow _row;
            public Row(DataRow row) 
            { 
                _row = row; 
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var value = _row.Table.Columns.Contains(binder.Name);
                result = value ? _row[binder.Name] : null;
                return value;
            }
        }
        public static IEnumerable<dynamic> AsDynamicEnumerable(this DataTable table)
        {
            return table.AsEnumerable().Select(row => new Row(row));
        }
    }
