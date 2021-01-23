    public class myComparer: IEqualityComparer  
    {
       public new bool Equals(object x, object y)
       {
          if (x is string )
             return  x ==   y;
          else if (x is Guid ) // maybe you want them to be equal if last char is equal. so you can do it here.
             return   x ==   y;
          else
             return EqualityComparer<object>.Default.Equals(x, y);
       }
    
       public int GetHashCode(object obj)
       {
          return EqualityComparer<object>.Default.GetHashCode(obj);
       }
    }
