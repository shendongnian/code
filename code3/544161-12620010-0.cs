    private class StructuralEqualityComparer<T> : EqualityComparer<T> where T : class
    {
        public override bool Equals(T x, T y)
        {
            return typeof(T).GetProperties()
                             .All(pro => pro.GetValue(x).Equals(pro.GetValue(y)));
    
        }
    
        public override int GetHashCode(T obj)
        {
            int hashCode = typeof(T).GetProperties()
                                    .Aggregate(0, (current, pro) => 
                                         current ^ pro.GetValue(obj).GetHashCode());
    
            return hashCode.GetHashCode();
        }
    }
