    public class StudentComparer : IEqualityComparer<string[]>
    {
      public bool Equals(string[] x, string[] y)
      {
        if(ReferenceEquals(x, y))
          return true;
        if(x == null || y == null)
          return false;
        return x.SequenceEqual(y);
      }
      public int GetHashCode(string[] arr)
      {
        return arr == null ? 0 : arr.Select(s => s == null ? 0 : s.GetHashCode()).Aggregate((x, y) => x ^ y);
      }
    }
