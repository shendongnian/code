    public class Element : IEqualityComparer<Element>
    {
       public bool Equals(Element x, Element y)
       {
         if (x.ID == y.ID)
         {
            return true;
         }
         else
         {
            return false;
         }
       }
    }
    public int GetHashCode(Element obj)
    {
        return obj.ID.GetHashCode();
    }
