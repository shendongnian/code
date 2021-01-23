    public class MsgComparer: IEqualityComparer<Msg>
    {
        public bool Equals(Msg x1, Msg x2)
        {
            if (object.ReferenceEquals(x1, x2))
                return true;
            if (x1 == null || x2 == null)
                return false;
            return x1.ID.Equals(x2.ID);
        }
        public int GetHashCode(Msg obj)
        {
            return obj.ID.GetHashCode();
        }
    }
