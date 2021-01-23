    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        public static extern int StrCmpLogicalW(string psz1, string psz2);
    }
    
    public sealed class NaturalOrderComparer : IComparer
    {
        public int Compare(object a, object b)
        {
            // replace DataItem with the actual class of the items in the ListView
            var lhs = (DataItem)a;
            var rhs = (DataItem)b;
            return SafeNativeMethods.StrCmpLogicalW(lhs.Order, rhs.Order);
        }
    }
