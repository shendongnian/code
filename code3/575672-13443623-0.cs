    public class CustomComparer : IEqualityComparer<ZRowCollection>
    {
        public static CustomComparer Instance { get { return new CustomComparer(); } }
    
        Int32 IEqualityComparer<ZRowCollection>.GetHashCode(ZRowCollection value)
        {
            //One could also use the sum of the averages here, but went for simplicity...
            return value.XRowModified.Count;
        }
    
        Boolean IEqualityComparer<ZRowCollection>.Equals(ZRowCollection z1, ZRowCollection z2)
        {
            return z1.XRowModified.Select(x => x.Average)
                                  .SequenceEqual(z2.XRowModified.Select(x => x.Average));
        }
    }
    
