    public class Vieta : IComparable, IComparable<Vieta>
    {
    
        IComparable.CompareTo( object obj )
        {
    
           var other = obj as Vieta;
    
           if( other == null ) return false;
    
           return CompareTo(other);
    
        }
    
    
        public int CompareTo( Vieta other )
        {
             // Implement your compare logic here.
        }
    
    }
