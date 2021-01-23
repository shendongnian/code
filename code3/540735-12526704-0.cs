    var result = OrigFruitList.Union(NormalFruitList,new FruitComparer())
    public class FruitComparer : IEqualityComparer<Fruit>
    {       
    
      public bool Equals(Fruit x, Fruit y)
      {
          return y.Category == y.Category && x.SubCategory == y.SubCategory;
      }
      public int GetHashCode(Fruit f)
      {
        return (f.Category + f.SubCategory).GetHashCode();
      }
    
    }
