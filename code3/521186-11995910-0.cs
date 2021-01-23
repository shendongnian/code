    public class NullEmptStringComparer : IComparer<string>
    {
      public Equals(string x, string y)
      {
        return (x ?? string.Empty) == (y ?? string.Empty);
      }
      public int GetHashCode(string str)
      {
        return (str ?? string.Empty).GetHashCode();
      }
    }
