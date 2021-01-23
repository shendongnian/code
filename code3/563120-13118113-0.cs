    public class CusComparer: IEqualityComparer<ICD_Map2>
    {
        public bool Equals(ICD_Map2 x, ICD_Map2 y)
        {
            return x.call_type.Equals(y.call_type) 
                  && x.destination.Equals(y.destination);
        }
        public int GetHashCode(ICD_Map2 obj)
        {
            return obj.call_type.GetHashCode() 
                     ^ obj.destination.GetHashCode();
        }
    }
