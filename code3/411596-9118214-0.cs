        public struct ColumnInfo
        {
            public string ColumnName { get; set; }
            public string DataType { get; set; }
            public int DataLength { get; set; }
            public class ColumnNameComparer : IEqualityComparer<ColumnInfo>
            {
                public bool Equals(ColumnInfo x, ColumnInfo y)
                {
                    return x.ColumnName == y.ColumnName;
                }
                public int GetHashCode(ColumnInfo obj)
                {
                    return obj.ColumnName.GetHashCode();
                }
            }
        }
