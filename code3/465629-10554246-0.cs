    public class ComparableBase :Base, IComparable<Base>
    {
    ....
    }
    
    class Class2 : ComparableBase 
    {
        public int CompareTo(Base other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
    }
    
    public static List<ComparableBase > BigList = new List<ComparableBase >();
