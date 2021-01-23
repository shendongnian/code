    public class DataRowComparer : IEqualityComparer<DataRow>
    {
        public bool Equals(DataRow x, DataRow y)
        {
            for (int i = 0; i < x.Table.Columns.Count; i++)
            {
                if(!object.Equals( x[i], y[i])
                    return false;
            }
            return true;
        }
    
        public int GetHashCode(DataRow obj)
        {
            unchecked
            {
                int output = 23;
                for (int i = 0; i < obj.Table.Columns.Count; i++)
                {
                    output += 19 * obj[i].GetHashCode();
                }
                return output;
            }
        }
    }
