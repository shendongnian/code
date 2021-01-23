        class DataColumnEqualityComparer : IEqualityComparer<DataColumn>
        {
            #region IEqualityComparer Members
            private DataColumnEqualityComparer() { }
            public static DataColumnEqualityComparer Instance = new DataColumnEqualityComparer();
    
            public bool Equals(DataColumn x, DataColumn y)
            {
                if (x.ColumnName != y.ColumnName)
                    return false;
                if (x.DataType != y.DataType)
                    return false;
                return true;
            }
            public int GetHashCode(DataColumn obj)
            {
                int hash = 17;
                hash = 31 * hash + obj.ColumnName.GetHashCode();
                hash = 31 * hash + obj.DataType.GetHashCode();
                return hash;
            }
            #endregion
        }
