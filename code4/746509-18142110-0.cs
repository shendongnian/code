    class ListSameByCount<T> : EqualityComparer<List<T>>
    {
      public override bool Equals(List<T> b1, List<T> b2)
      {
        return b1.Count() == b2.Count();
      }
    
      public override int GetHashCode(List<T> b1)
      {
        return b1.Count().GetHashCode();
      }
    }
    var dictionary = new Dictionary<List<int>, int>(new ListSameByCount<int>());
