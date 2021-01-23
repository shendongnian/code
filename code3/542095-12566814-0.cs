        public class StringArrayComparer : IEqualityComparer<string[]>
        {
            public bool Equals(string[] x, string[] y)
            {
                return StructuralComparisons.StructuralEqualityComparer.Equals(x, y);
            }
            public int GetHashCode(string[] obj)
            {
                return StructuralComparisons.StructuralEqualityComparer.GetHashCode(obj);
            }
        }
