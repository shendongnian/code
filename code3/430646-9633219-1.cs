    class CustomComparer : IEqualityComparer<DataRow>
    {
        #region IEqualityComparer<DataRow> Members
    
        public bool Equals(DataRow x, DataRow y)
        {
            return ((string)x["Name"]).Equals((string)y["Name"]);
        }
    
        public int GetHashCode(DataRow obj)
        {
            return ((string)obj["Name"]).GetHashCode();
        }
    
        #endregion
    }
