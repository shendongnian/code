    public class MyComparer : IEqualityComparer<Test>
    {
        public bool Equals(Test x, Test y)
        {
            return x.ColumnA == y.ColumnA && x.ColumnB == y.ColumnB && x.ColumnC == y.ColumnC;
        }
        public int GetHashCode(Test obj)
        {
            // todo, implement
        }
    }
