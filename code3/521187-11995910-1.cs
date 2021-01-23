    public class NullEmptCustStringComparer : IComparer<string>
    {
      private readonly IComparer<string> _baseCmp;
      public NullEmptCustStringComparer(IComparer<string> baseCmp)
      {
        _baseCmp = baseCmp;
      }
      public Equals(string x, string y)
      {
        return _baseCmp.Equals(x ?? string.Empty, y ?? string.Empty);
      }
      public int GetHashCode(string str)
      {
        return _baseCmp.GetHashCode(str ?? string.Empty);
      }
    }
