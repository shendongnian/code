    public class ItemsDTO: IEqualityComparer<ItemsDTO>
    {
      public bool Equals(ItemsDTO x, ItemsDTO y)
      {
        if (x == null || y == null) return false;
    
        return ReferenceEquals(x, y) || (x.Id == y.Id); // In this example, treat the items as equal if they have the same Id
      }
    
      public int GetHashCode(ItemsDTO obj)
      {
        return this.Id.GetHashCode();
      }
    }
