    public sealed class NaturalStringComparer : IComparer<string>
    {
      public static readonly NaturalStringComparer Default = new NaturalStringComparer();
      public int Compare(string x, string y)
      {
        return SafeNativeMethods.StrCmpLogicalW(x, y);
      }
    }
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
      [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
      public static extern int StrCmpLogicalW(string psz1, string psz2);
    }
