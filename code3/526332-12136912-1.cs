     public class CustomDataRowComparer : IEqualityComparer<DataRow>
        {
            public bool Equals(DataRow x, DataRow y)
            {
                for (int i = 0; i < x.Table.Columns.Count; i++)
                {
                    if (x[i].ToString() != y[i].ToString())
                    {
                        return false;
                    }
    
                }
                return true;
            }
    
            public int GetHashCode(DataRow obj)
            {
                return obj.ToString().GetHashCode();
            }
        }
