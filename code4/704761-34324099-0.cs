    #region IEqualityComparer<pcf> Members
    public bool Equals(Employe x, Employe y)
    {
        if (x.fName.Equals(y.fName) && x.lName.Equals(y.lName))
        {
            return true;
        }
        return false;
    }
    public int GetHashCode(Employe obj)
    {
        return obj.GetHashCode();
    }
    #endregion
