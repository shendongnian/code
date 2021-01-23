    private class GroupKey
    {
        public string Column1{ get; set; }
        public string Column2{ get; set; }
        public GroupKey(SourceObject r) {
            this.Column1 = r.Column1;
            this.Column2 = r.Column2;
        }
    }
    private class KeyComparer: IEqualityComparer<GroupKey>
    {
        bool IEqualityComparer<GroupKey>.Equals(GroupKey x, GroupKey y)
        {
            if (!x.Column1.Equals(y.Column1,StringComparer.InvariantCultureIgnoreCase) return false;
            if (!x.Column2.Equals(y.Column2,StringComparer.InvariantCultureIgnoreCase) return false;
            return true;
            //my actual code is more complex than this, more columns to compare
            //and handles null strings, but you get the idea.
        }
        int IEqualityComparer<GroupKey>.GetHashCode(GroupKey obj)
        {
            return 0.GetHashCode() ; // forces calling Equals
            //Note, it would be more efficient to do something like
            //string hcode = Column1.ToLower() + Column2.ToLower();
            //return hcode.GetHashCode();
            //but my object is more complex than this simplified example
        }
    }
