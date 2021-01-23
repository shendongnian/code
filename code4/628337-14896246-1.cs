     public class PairComparer : IEqualityComparer<IList<int>>
    {
    
      public bool Equals(IList<int> x, IList<int> y)
      {
        return x.All(i => y.Contains(i));
      }
  
      public int GetHashCode(IList<int> obj)
      {
        return obj.Sum(x => x.GetHashCode());
      }
    }
