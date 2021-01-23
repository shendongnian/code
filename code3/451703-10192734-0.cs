    public class FooDeptCourseEqualityComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            return
                x.Dept == y.Dept &&
                x.Course.ToLower() == y.Course.ToLower();
        }
        public int GetHashCode(Foo obj)
        {
            return obj.Dept.GetHashCode() ^ obj.Course.GetHashCode();
        }
        #region Singleton Pattern
        public static readonly FooDeptCourseEqualityComparer Instance = new FooDeptCourseEqualityComparer();
        private FooDeptCourseEqualityComparer() { }
        #endregion
    }
