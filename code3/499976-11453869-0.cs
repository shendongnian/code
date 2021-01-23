        /// <summary>
        /// Equality comparer with a tolerance equivalent to using the 'EqualWithTolerance' method
        /// 
        /// Note: since it's pretty much impossible to have working hash codes
        /// for a "fuzzy" comparer the GetHashCode method throws an exception.
        /// </summary>
        public class EqualityComparerWithTolerance : IEqualityComparer<Vec3>
        {
            private float tolerance;
            public EqualityComparerWithTolerance(float tolerance = MathFunctions.Epsilon)
            {
                this.tolerance = tolerance;
            }
            public bool Equals(Vec3 v1, Vec3 v2)
            {
                return v1.EqualWithinTolerance(v2, tolerance);
            }
            public int GetHashCode(Vec3 obj)
            {
                throw new NotImplementedException();
            }
        }
