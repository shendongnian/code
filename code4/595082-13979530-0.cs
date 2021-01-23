    public class ObjectArrayComparer : EqualityComparer<object[]>
    {
        public override bool Equals(object[] o1, object[] o2)
        {
            return Enumerable.SequenceEqual(o1, o2);
        }
        
        public override int GetHashCode(object[] obj)
        {
            string concatenated = obj.Aggregate((current, working) => working = (string)working + (string)current).ToString();
            
            return concatenated.GetHashCode();
        }
    }
