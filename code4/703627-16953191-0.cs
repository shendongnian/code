    public class CustomComparer : IEqualityComparer<WarningClass>
    {
        public bool Equals(WarningClass x, WarningClass y)
        {
            return x.SqlEyeWarning.Equals(y.SqlEyeWarning)
                   && x.FileName.Equals(y.FileName);
        }
        public int GetHashCode(WarningClass obj)
        {
            return obj.FileName.GetHashCode() 
                ^ obj.SqlEyeWarning.GetHashCode();
        }
    }
