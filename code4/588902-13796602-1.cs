    public class ComparerDateTime : IComparer
    {
        public int Compare(object x, object y)
        {
            MYCLASS X = x as MYCLASS;
            MYCLASS Y = y as MYCLASS;
    
            return X.date.CompareTo(Y.date);
        }
    }
    
     MYCLASSList.Sort(new ComparerDateTime ());
