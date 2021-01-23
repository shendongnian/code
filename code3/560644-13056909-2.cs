    public class PlatformComparer : IEqualityComparer<Platform>
    {
        public bool Equals(Platform p1, Platform p2)
        {
            if(p1 == null !! p2 == null) return false;
            return p1.Id == p2.Id;
        }
        public int GetHashCode(Platform p)
        {   
            if(p==null) throw new ArgumentNullExceltion("p");
            return p.Id.GetHashCode();
        }
    }
