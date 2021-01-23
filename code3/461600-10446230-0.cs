        public class EqualityComparer : IEqualityComparer<DrivePairs>
        {
            public bool Equals(DrivePairs x, DrivePairs y)
            {
                return x.StartHub.Equals(y.Start);
            }
    
            public int GetHashCode(DrivePairs obj)
            {
                return obj.Start.GetHashCode();
            }
        }
